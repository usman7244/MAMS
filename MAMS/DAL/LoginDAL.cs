using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDAL
    {
        private readonly IConfiguration _configuration;

        public LoginDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginDAL()
        {

        }

        public async Task<User> Authenticate(User user, ISqlConnectionFactory connectionFactory)
        {
            User login = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetUserByEmail] @Email";

            login = await connection.QueryFirstOrDefaultAsync<User>(SQLQuery, new { Email = user.Email });

            login.Password = Decrypt(login.Password, "mams@74");
            if (login != null && login.Password == user.Password)
            {
                var token = GenerateJwtToken(login);
                return new User
                {
                    Status = "Success",
                    // Token = token
                    Email = login.Email,
                    Password = login.Password,
                    Name = login.Name,
                    UID = login.UID,
                    RoleID = login.RoleID,
                    BranchUID = login.BranchUID
                };
            }
            else
            {
                return new User
                {
                    Status = "Invalid",
                    //Token = null
                };
            }
        }
        public string GenerateJwtToken(User login)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new List<Claim>()
            {
             new Claim(JwtRegisteredClaimNames.Sub, login.UID.ToString()),
             new Claim(JwtRegisteredClaimNames.NameId, login.Name.ToString()),
             new Claim(JwtRegisteredClaimNames.UniqueName, login.Email),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString()),
              new Claim(ClaimTypes.Role.ToString(), login.RoleID.ToString())
              };
  
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C428A377979E395725A6A1A13A0CE0D25F1B30B7DAE0EFB06F26F79EDC149472"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddDays(7),
                audience: "api.mams.build",
                issuer: "api.mams.build"
                );
      
            string data = new JwtSecurityTokenHandler().WriteToken(jwt);
            return data;
        }

        public string Decrypt(string cipherText, string encryptionKey)
        {
            try
            {
              
                cipherText = cipherText.Replace(" ", "+");

               
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (Aes encryptor = Aes.Create())
                {
                
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    // Create a MemoryStream to hold decrypted data
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Create a CryptoStream to perform decryption
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            // Write decrypted bytes to CryptoStream
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        // Convert MemoryStream to string using Unicode encoding
                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("An error occurred while decrypting the text: " + ex.Message);
                return null;
            }
        }




    }
}

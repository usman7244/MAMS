using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class CompanyDAL
    {
        private List<Company> _companyList;
        private Company _company;

        public CompanyDAL()
        {
            _companyList = new List<Company>();
            _company = new Company();
        }
        public async Task<List<Company>> GetCompanyInfo( ISqlConnectionFactory connectionFactory)
        {

            var _companyList = new List<Company>();

            try
            {
              
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spGetCompany] ";

                var Company = await connection.QueryAsync<Company>(SQLQuery, new { });

                _companyList = Company.ToList();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return _companyList;
        }
        public async Task<int> CompanyAdd(Company company, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;

            try
            {
                company.UID = Guid.NewGuid();
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spAddCompany] @Name, @Status, @CreatedBy";

                affectedRows = await connection.ExecuteAsync(SQLQuery, new
                {
                    Name = company.Name,
                    Status = company.Status,
                    CreatedBy = company.CreatedBy
                });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return affectedRows;
        }

        public async Task<int> DeleteCompany(Company company, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteCompany] @UID";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = company.UID});

            return effectedRows;
        }
        public async Task<Company> GetSpecificCompanyInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            Company company = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetSpecificCompany] @UID";

            company = await connection.QueryFirstOrDefaultAsync<Company>(SQLQuery, new { UID = Id });

            return company;
        }


        public async Task<int> EditCompany(Company company, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spUpdateCompany] @UID, @Name, @ModifiedBy,@Status";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = company.UID, Name = company.Name, ModifiedBy = company.ModifiedBy, Status = company.Status });

            return effectedRows;
        }

    }
}

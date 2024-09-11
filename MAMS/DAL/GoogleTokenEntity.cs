using System;

namespace DAL
{
    public class GoogleTokenEntity
    {
        public object UserId { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public long? ExpiresInSeconds { get; set; }
        public string IdToken { get; set; }
        public DateTime IssuedUtc { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
        public bool Drive { get; set; }
    }
}
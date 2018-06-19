using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SLEntities;


namespace SLHelpers
{
    static public class TokenHelpers
    {
        static IConfiguration _config;

        static TokenHelpers()
        {
            _config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();
        }

        static public string BuildUserToken(User user)
        {
            if (user == null)
                throw SLExceptionManager.Wrap(new ArgumentNullException(nameof(user), "L'argument ne peut pas être NULL."));

            if(!_config.ContainsKey("Issuer"))
                throw SLExceptionManager.Wrap(new ArgumentException(nameof(user), "la clé 'Jwt:Issuer' est absente de la configuration."));

            if (!_config.ContainsKey("Jwt:Key"))
                throw SLExceptionManager.Wrap(new ArgumentException(nameof(user), "la clé 'Jwt:Key' est absente de la configuration."));

            string issuer = _config["Jwt:Issuer"];
            string securityKey = _config["Jwt:Key"];
            double.TryParse(_config["Jwt:ExpiresMinutes"], out double expireDelay);

            if (issuer.IsNullOrWhiteSpace())
                throw SLExceptionManager.Wrap(new ArgumentNullException(nameof(issuer), "L'argument ne peut pas être NULL."));

            if (securityKey.IsNullOrWhiteSpace())
                throw SLExceptionManager.Wrap(new ArgumentNullException(nameof(securityKey), "L'argument ne peut pas être NULL."));


            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
              issuer,
              claims,
              expires: DateTime.Now.AddMinutes(expireDelay),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

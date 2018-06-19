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

            if(!_config.ContainsSection(ConfigurationCodes.JwtIssuerKey))
                throw SLExceptionManager.Wrap(new NullReferenceException($"la clé '{ConfigurationCodes.JwtIssuerKey}' est absente de la configuration."));

            if (!_config.ContainsSection(ConfigurationCodes.JwtKeyKey))
                throw SLExceptionManager.Wrap(new NullReferenceException($"la clé '{ConfigurationCodes.JwtKeyKey}' est absente de la configuration."));

            string issuer = _config.GetSectionValue(ConfigurationCodes.JwtIssuerKey);
            string securityKey = _config.GetSectionValue(ConfigurationCodes.JwtIssuerKey);
            double.TryParse(_config.GetSectionValue(ConfigurationCodes.JwtExpiresKey), out double expireDelay);

            if (issuer.IsNullOrWhiteSpace())
                throw SLExceptionManager.Wrap(new NullReferenceException($"La propriété {nameof(issuer)} ne peut pas être NULL."));

            if (securityKey.IsNullOrWhiteSpace())
                throw SLExceptionManager.Wrap(new NullReferenceException($"La propriété {nameof(securityKey)} ne peut pas être NULL."));


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

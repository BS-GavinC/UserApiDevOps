using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIUserDevOps.Helpers
{
    // JWT : Json Web Token
    public class JwtHelper
    {
        // Permet de recup les valeurs du "appsettings.json"
        private readonly IConfiguration _Configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string CreateToken(UserModel userModel)
        {
            // Génération des credentials du token
            SecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"])
            ) ;

            SigningCredentials credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha512
            );

            // Informations qui seront contenu dans le JWT
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                new Claim(ClaimTypes.Email, userModel.Email),
                new Claim(ClaimTypes.Role, userModel.IsAdmin ? "Admin" : "User")
            };

            // Création du token de securité (JWT)
            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: claims,
                issuer: _Configuration["JWT:Issuer"],
                audience: _Configuration["JWT:Audience"],
                expires : DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            // Envoi du token sous la forme d'une chaine de caracteres
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}

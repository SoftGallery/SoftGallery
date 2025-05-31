using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace SoftGallery.Dominio.Services
{
    public class AuthService
    {
        private readonly SoftGalleryDominioDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthService(SoftGalleryDominioDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        private string GenerateToken(Cliente cliente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, cliente.Nome),
                    new Claim(ClaimTypes.Email, cliente.Email),
                    new Claim("id", cliente.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public Cliente Me()
        {

            var user = httpContextAccessor.HttpContext?.User;

            if (user == null || !(user.Identity?.IsAuthenticated ?? false))
            {
                throw new UnauthorizedAccessException("Usuário não autenticado");
            }

            var clienteId = AuthUtils.GetClienteId(user);

            var cliente = dbContext.Clientes.Find(clienteId.ToString());
            if (cliente is null)
            {
                throw new UnauthorizedAccessException("Cliente não encontrado");
            }

            return cliente;
        }

        public string SignIn(SignInDTO parametros)
        {
            Cliente? cliente = dbContext
                .Clientes
                .FirstOrDefault(
                    cliente => cliente.Email == parametros.Email && cliente.Senha == parametros.Senha
                );

            if (cliente is null)
            {
                return null;
            }

            return GenerateToken(cliente);
        }
    }
}


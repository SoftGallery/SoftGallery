using System.Security.Claims;

namespace SoftGallery.Dominio.Utils
{
    public class AuthUtils
    {
        public static Guid GetClienteId(ClaimsPrincipal user)
        {
            var clienteId = user.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (clienteId == null)
            {
                throw new UnauthorizedAccessException("Claim 'id' não encontrada");
            }

            return Guid.Parse(clienteId);
        }
    }
}

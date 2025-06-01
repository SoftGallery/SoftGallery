using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.Services;

namespace SoftGallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatsAppController : ControllerBase
    {
        private readonly WhatsAppService whatsAppService;

        public WhatsAppController(WhatsAppService whatsAppService)
        {
            this.whatsAppService = whatsAppService;
        }

        [HttpGet("url/{pedidoId}")]
        public ActionResult<string> GetUrlWhatsapp(string pedidoId)
        {
            try
            {
                string url = whatsAppService.GerarUrlWhatsapp(pedidoId);
                return Ok(url);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}

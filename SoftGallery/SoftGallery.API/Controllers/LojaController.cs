using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;

namespace SoftGallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {
        private readonly LojaService service;

        public LojaController(LojaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<Loja> Get()
        {
            var config = service.ObterConfiguracao();
            if (config == null)
                return NotFound();

            return Ok(config);
        }

        [HttpPut]
        public IActionResult Put([FromBody] LojaDTO dto)
        {
            service.UpsertConfiguracao(dto);
            return NoContent();
        }
    }

}

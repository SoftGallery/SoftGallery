using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;
using static SoftGallery.Dominio.DTO.LojaDTO;

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
        public IActionResult Put([FromBody] LojaDTOInput dto)
        {
            service.UpsertConfiguracao(dto);
            return NoContent();
        }

        [HttpPost("{id}/Upload")]
        public async Task<ActionResult<Loja>> UploadImage(string id, IFormFile arquivo)
        {
            try
            {
                Loja loja = await service.UploadImage(id, arquivo);
                return Ok(loja);
            }
            catch (RecursoNaoEncontradoException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }

}

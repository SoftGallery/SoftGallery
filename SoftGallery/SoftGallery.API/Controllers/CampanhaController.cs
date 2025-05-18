using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;

namespace SoftGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        private readonly CampanhaService service;

        public CampanhaController(CampanhaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Campanha>> GetCampanhas([FromQuery] bool? ativas = false)
        {
            var campanhas = service.ListarCampanhas(ativas.GetValueOrDefault());
            return Ok(campanhas);
        }

        [HttpGet("{id}")]
        public ActionResult<Campanha> GetCampanha(string id)
        {
            var campanha = service.RetornarCampanha(id);
            if (campanha == null)
            {
                return NotFound();
            }

            return Ok(campanha);
        }

        [HttpPost]
        public ActionResult<Campanha> CreateCampanha([FromBody] CampanhaDTO novaCampanhaDTO)
        {
            var novaCampanha = service.CriarCampanha(novaCampanhaDTO);
            return CreatedAtAction(nameof(GetCampanha), new { id = novaCampanha.Id }, novaCampanha);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCampanha(string id, [FromBody] CampanhaDTO campanhaAtualizadaDTO)
        {
            bool atualizada = service.EditarCampanha(id, campanhaAtualizadaDTO);
            if (!atualizada)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCampanha(string id)
        {
            bool removida = service.DeleteCampanha(id);
            if (!removida)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;
using static SoftGallery.Dominio.DTO.CampanhaDTO;

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

        [HttpGet("{id}/produtos")]
        public ActionResult<ProdutosCampanhaDTO> GetProdutosCampanha(string id)
        {
            var campanha = service.RetornarProdutosCampanha(id);
            if (campanha == null)
            {
                return NotFound();
            }

            return Ok(campanha);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutosCampanhaDTO> GetCampanha(string id)
        {
            var campanha = service.RetornarCampanha(id);
            if (campanha == null)
            {
                return NotFound();
            }

            return Ok(campanha);
        }

        [HttpPost]
        public ActionResult<Campanha> CreateCampanha([FromBody] CampanhaDTOInput novaCampanhaDTO)
        {
            Campanha novaCampanha = service.CriarCampanha(novaCampanhaDTO);
            return CreatedAtAction(nameof(GetCampanha), new { id = novaCampanha.Id }, novaCampanha);
        }

        [HttpPost("{id}/Upload")]
        public async Task<ActionResult<Campanha>> UploadImage(string id, IFormFile arquivo)
        {
            try
            {
                Campanha campanha = await service.UploadImage(id, arquivo);
                return Ok(campanha);
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

        [HttpPut("{id}")]
        public IActionResult UpdateCampanha(string id, [FromBody] CampanhaDTOInput campanhaAtualizadaDTO)
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

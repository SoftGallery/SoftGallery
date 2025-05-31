using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;

namespace SoftGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService service;

        public ProdutoController(ProdutoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResumoProdutoDTO>> GetProdutos([FromQuery] string? ordenarPor = null, [FromQuery] string? direcao = "asc")
        {
            List<ResumoProdutoDTO> produtos = service.ListarProdutos(ordenarPor, direcao);
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProduto(string id)
        {
            ProdutoDTO? produto = service.RetornaProduto(id);

            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> CreateProduto([FromBody] ProdutoDTO novoProdutoDTO)
        {
            ProdutoDTO produto = service.CriarProduto(novoProdutoDTO);
            return CreatedAtAction(nameof(CreateProduto), produto);
        }

        [HttpPost("{id}/Upload")]
        public async Task<ActionResult<Produto>> UploadImage(string id, IFormFile arquivo)
        {
            try
            {
                var produto = await service.UploadImage(id, arquivo);
                return Ok(produto);
            }
            catch (ProdutoInexistente ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(string id, ProdutoDTO updateProduto)
        {
            bool editProduct = service.EditarProduto(id, updateProduto);

            if (!editProduct)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(string id)
        {
            bool deleteProduct = service.DeleteProduto(id);

            if (!deleteProduct)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

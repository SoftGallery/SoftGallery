using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.DTO;
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
        public ActionResult<IEnumerable<Produto>> GetProdutos([FromQuery] string? ordenarPor = null, [FromQuery] string? direcao = "asc")
        {
            List<Produto> produtos = service.ListarProdutos(ordenarPor, direcao);
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Produto>> GetProduto(string id)
        {
            Produto? produto = service.RetornaProduto(id);

            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> CreateProduto([FromBody] ProdutoDTO novoProdutoDTO)
        {
            Produto produto = service.CriarProduto(novoProdutoDTO);
            return CreatedAtAction(nameof(CreateProduto), produto);
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

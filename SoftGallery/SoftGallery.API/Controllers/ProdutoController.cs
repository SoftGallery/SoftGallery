﻿using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;
using static SoftGallery.Dominio.DTO.ProdutoDTO;

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
        public ActionResult<Produto> CreateProduto([FromBody] ProdutoDTOListagem novoProdutoDTO)
        {
            Produto produto = service.CriarProduto(novoProdutoDTO);
            return CreatedAtAction(nameof(CreateProduto), produto);
        }

        [HttpPost("{id}/Upload")]
        public async Task<ActionResult<Produto>> UploadImage(string id, IFormFile arquivo)
        {
            try
            {
                Produto produto = await service.UploadImage(id, arquivo);
                return Ok(produto);
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
        public IActionResult UpdateProduto(string id, ProdutoDTOListagem updateProduto)
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

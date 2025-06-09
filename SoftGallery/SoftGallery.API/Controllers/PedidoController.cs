using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;
using System.Security.Claims;

namespace SoftGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly PedidoService service;

        public PedidosController(PedidoService service)
        {
            this.service = service;
        }
        //[Authorize]
        [HttpPost]
        public ActionResult<Pedido> CriarPedido([FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                var pedido = service.CreatePedido(pedidoDTO);
                return CreatedAtAction(nameof(ObterPedidoPorId), new { id = pedido.Id }, pedido);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
            catch (RecursoNaoEncontradoException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno no servidor", detalhes = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Pedido> AtualizarPedido(string id, [FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                var pedidoAtualizado = service.UpdatePedido(id, pedidoDTO);
                return Ok(pedidoAtualizado);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
            catch (RecursoNaoEncontradoException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno no servidor", detalhes = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Pedido> ObterPedidoPorId(string id)
        {
            var pedido = service.ObterPedidoPorId(id);
            if (pedido == null)
            {
                return NotFound(new { mensagem = "Pedido não encontrado" });
            }

            return Ok(pedido);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            var pedidos = service.GetAllPedidos();
            return Ok(pedidos);
        }

    }
}

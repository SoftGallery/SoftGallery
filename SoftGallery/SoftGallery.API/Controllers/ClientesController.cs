using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;
using static SoftGallery.Dominio.DTO.ClienteDTO;

namespace SoftGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService service;

        public ClientesController(ClientesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTOOutput>> Get()
        {
            IEnumerable<ClienteDTOOutput> clientes = service.GetClientes();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTOOutput> GetCliente(string id)
        {
            ClienteDTOOutput cliente = service.GetCliente(id);
            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> CreateCliente(ClienteDTOInput novoClienteDTO)
        {

            Cliente novoCliente = service.CreateCliente(novoClienteDTO);

            if (novoCliente is null)
            {
                return BadRequest("Já existe um cliente com este CPF");
            }

            return CreatedAtAction(nameof(CreateCliente), novoCliente);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateCliente(string id, ClienteDTOInput clienteAAtualizarDTO)
        {
            try
            {
                bool editClient = service.UpdateCliente(id, clienteAAtualizarDTO);

                if (!editClient)
                {
                    return BadRequest("Já existe um cliente com este CPF");
                }

                return NoContent();
                
            }
            catch (RecursoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(string id)
        {
            bool clienteEncontrado = service.DeleteCliente(id);

            if (!clienteEncontrado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
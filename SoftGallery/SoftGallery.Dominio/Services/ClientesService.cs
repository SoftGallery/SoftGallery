using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using static SoftGallery.Dominio.DTO.ClienteDTO;

namespace SoftGallery.Dominio.Services
{
    public class ClientesService
    {
        private readonly SoftGalleryDominioDbContext dbContext;

        public ClientesService(SoftGalleryDominioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ClienteDTOOutput> GetClientes()
        {
            IEnumerable<ClienteDTOOutput> clientes = dbContext
               .Clientes
               .Select(
                   c => new ClienteDTOOutput(c.Id, c.Nome, c.Email, c.CPF)
               );
            return clientes.ToList();
        }

        public ClienteDTOOutput GetCliente(string id)
        {
            Cliente? cliente = dbContext
                .Clientes
                .FirstOrDefault(p => p.Id == id);

            if (cliente is null)
            {
                return null;
            }

            ClienteDTOOutput clienteDTO = new ClienteDTOOutput(cliente.Id, cliente.Nome, cliente.Email, cliente.CPF);

            return clienteDTO;
        }

        public Cliente CreateCliente(ClienteDTOInput novoClienteDTO)
        {
            if (dbContext.Clientes.Any(cliente => cliente.CPF.Equals(novoClienteDTO.CPF)))
            {
                return null;
            }

            Cliente novoCliente = new Cliente(novoClienteDTO.Nome, novoClienteDTO.Email, novoClienteDTO.Senha, novoClienteDTO.CPF);

            dbContext.Clientes.Add(novoCliente);
            dbContext.SaveChanges();

            return novoCliente;
        }

        public bool UpdateCliente(string id, ClienteDTOInput clienteAAtualizarDTO)
        {
            Cliente? clienteEncontrado =
                dbContext
                .Clientes
                .FirstOrDefault(p => p.Id == id);

            if (clienteEncontrado == null)
            {
                throw new RecursoNaoEncontradoException("Cliente não existe");
            }

            if (dbContext.Clientes.Any(cliente => cliente.Id != id && cliente.CPF.Equals(clienteAAtualizarDTO.CPF)))
            {
                return false;
            }

            clienteEncontrado.Nome = clienteAAtualizarDTO.Nome;
            clienteEncontrado.Email = clienteAAtualizarDTO.Email;
            clienteEncontrado.Senha = clienteAAtualizarDTO.Senha;
            clienteEncontrado.CPF = clienteAAtualizarDTO.CPF;

            dbContext.SaveChanges();

            return true;
        }

        public bool DeleteCliente(string id)
        {
            Cliente? clienteEncontrado =
                dbContext
                .Clientes
                .FirstOrDefault(p => p.Id == id);

            if (clienteEncontrado == null)
            {
                return false;
            }

            dbContext.Clientes.Remove(clienteEncontrado);
            dbContext.SaveChanges();

            return true;
        }
    }
}

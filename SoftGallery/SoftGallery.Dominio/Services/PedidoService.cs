using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Utils;

namespace SoftGallery.Dominio.Services
{
    public class PedidoService
    {
        private readonly SoftGalleryDominioDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PedidoService(SoftGalleryDominioDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Pedido CreatePedido(PedidoDTO novoPedidoDTO)
        {
            if (novoPedidoDTO.ProdutosIds.Length == 0)
            {
                throw new ArgumentException("É necessário enviar os ids dos produtos");
            }

            List<Produto> produtos = dbContext.Produtos
                .Where(produto => novoPedidoDTO.ProdutosIds.Contains(produto.Id))
                .ToList();

            if (produtos.Count != novoPedidoDTO.ProdutosIds.Length)
            {
                throw new RecursoNaoEncontradoException("Um ou mais produtos não foram encontrados.");
            }


            var user = httpContextAccessor.HttpContext?.User;

            if (user == null || !(user.Identity?.IsAuthenticated ?? false))
            {
                throw new UnauthorizedAccessException("Usuário não autenticado");
            }

            var clienteId = AuthUtils.GetClienteId(user);

            var cliente = dbContext.Clientes.Find(clienteId.ToString());
            if (cliente == null)
            {
                throw new RecursoNaoEncontradoException("Cliente não encontrado.");
            }

            var novoPedido = new Pedido(produtos, cliente, DateTime.Now);

            dbContext.Pedidos.Add(novoPedido);
            dbContext.SaveChanges();

            return novoPedido;
        }

        public Pedido? ObterPedidoPorId(string id)
        {
            return dbContext.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Produtos)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> GetAllPedidos()
        {
            return dbContext.Pedidos
                .Include(p => p.Produtos)
                .Include(p => p.Cliente)
                .ToList();
        }

        public Pedido UpdatePedido(string id, PedidoDTO pedidoAtualizadoDTO)
        {
            var pedidoExistente = dbContext.Pedidos
                .Include(p => p.Produtos)
                .Include(p => p.Cliente)
                .FirstOrDefault(p => p.Id == id);

            if (pedidoExistente == null)
            {
                throw new RecursoNaoEncontradoException("Pedido não encontrado.");
            }

            if (pedidoAtualizadoDTO.ProdutosIds.Length == 0)
            {
                throw new ArgumentException("É necessário enviar os ids dos produtos");
            }

            List<Produto> produtos = dbContext.Produtos
                .Where(produto => pedidoAtualizadoDTO.ProdutosIds.Contains(produto.Id))
                .ToList();

            if (produtos.Count != pedidoAtualizadoDTO.ProdutosIds.Length)
            {
                throw new RecursoNaoEncontradoException("Um ou mais produtos não foram encontrados.");
            }

            // Atualiza os produtos
            pedidoExistente.Produtos = produtos;

            // Você pode atualizar outras propriedades se existirem

            dbContext.SaveChanges();

            return pedidoExistente;
        }


    }
}

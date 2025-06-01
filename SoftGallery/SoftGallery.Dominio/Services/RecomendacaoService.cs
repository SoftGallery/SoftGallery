using Microsoft.EntityFrameworkCore;
using SoftGallery.Dominio.Models;

namespace SoftGallery.Dominio.Services
{
    public class RecomendacaoService
    {
        private readonly SoftGalleryDominioDbContext dbContext;

        public RecomendacaoService(SoftGalleryDominioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Produto> ObterProdutosRecomendados(string clienteId, int limite = 5)
        {
            // Produtos que o cliente já comprou
            var produtosDoCliente = dbContext.Pedidos
                .Where(p => p.Cliente.Id == clienteId)
                .SelectMany(p => p.Produtos)
                .Select(p => p.Id)
                .Distinct()
                .ToHashSet();

            if (!produtosDoCliente.Any())
            {
                return dbContext.Produtos
                    .Take(limite)
                    .ToList();
            }

            // Buscar pedidos de outros clientes que possuem produtos semelhantes
            var pedidosRelacionados = dbContext.Pedidos
                .Where(p => p.Produtos.Any(prod => produtosDoCliente.Contains(prod.Id)) && p.Cliente.Id != clienteId)
                .Include(p => p.Produtos)
                .ToList();

            // Contar frequência dos produtos nesses pedidos
            var contadorProdutos = pedidosRelacionados
                .SelectMany(p => p.Produtos)
                .Where(p => !produtosDoCliente.Contains(p.Id))
                .GroupBy(p => p.Id)
                .Select(g => new
                {
                    Produto = g.First(),
                    Quantidade = g.Count()
                })
                .OrderByDescending(p => p.Quantidade)
                .Take(limite)
                .Select(p => p.Produto)
                .ToList();

            return contadorProdutos;
        }

    }
}

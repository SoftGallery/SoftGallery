using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Models;

namespace SoftGallery.Dominio.Services
{
    public class ProdutoService
    {
        private readonly SoftGalleryDominioDbContext dbContext;

        public ProdutoService(SoftGalleryDominioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Produto> ListarProdutos(string? ordenarPor, string? direcao)
        {
            var query = dbContext.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(ordenarPor))
            {
                switch (ordenarPor.ToLower())
                {
                    case "nome":
                        query = direcao == "desc" ? query.OrderByDescending(p => p.Nome) : query.OrderBy(p => p.Nome);
                        break;
                    case "preco":
                        query = direcao == "desc" ? query.OrderByDescending(p => p.Preco) : query.OrderBy(p => p.Preco);
                        break;
                    default:
                        break;
                }
            }

            return query.ToList();
        }

        public Produto RetornaProduto(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);
            return produto;
        }

        public Produto CriarProduto(ProdutoDTO produto)
        {
            Produto novoProduto = new Produto(produto.Nome, produto.Preco, produto.Descricao);

            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();
            return novoProduto;
        }

        public bool EditarProduto(string id, ProdutoDTO produto)
        {
            Produto? produtoEncontrado =
                dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return false;
            }

            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProduto(string id)
        {
            Produto? produtoEncontrado =
                dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return false;
            }

            dbContext.Produtos.Remove(produtoEncontrado);
            dbContext.SaveChanges();
            return true;
        }
    }
}

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
        public List<Produto> ListarProdutos()
        {
            return dbContext.Produtos.ToList();
        }

        public Produto RetornaProduto(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);
            return produto;
        }

        public bool CriarProduto(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
                return false;
            }

            dbContext.Produtos.Add(produto);
            dbContext.SaveChanges();
            return true;
        }

        public bool EditarProduto(string id, Produto produto)
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

using Microsoft.AspNetCore.Http;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;

namespace SoftGallery.Dominio.Services
{
    public class ProdutoService
    {
        private readonly SoftGalleryDominioDbContext dbContext;
        private readonly UrlServico servicoUrl;

        public ProdutoService(SoftGalleryDominioDbContext dbContext, UrlServico servicoUrl)
        {
            this.dbContext = dbContext;
            this.servicoUrl = servicoUrl;
        }
        public List<ResumoProdutoDTO> ListarProdutos(string? ordenarPor, string? direcao)
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

            var produtosDTO = query.Select(p => new ResumoProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                imagemUrl = p.ImagemURL ?? string.Empty
            }).ToList();

            return produtosDTO;
        }

        public ProdutoDTO RetornaProduto(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);
            ProdutoDTO produtoDTO = new ProdutoDTO
            {
                Nome = produto?.Nome ?? string.Empty,
                Descricao = produto?.Descricao ?? string.Empty,
                Preco = produto?.Preco ?? 0,
                imagemUrl = produto?.ImagemURL ?? string.Empty
            };
            return produtoDTO;
        }

        public ProdutoDTO CriarProduto(ProdutoDTO produto)
        {
            Produto novoProduto = new Produto(produto.Nome, produto.Preco, produto.Descricao, produto.imagemUrl);

            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();
            ProdutoDTO novoProdutoDTO = new ProdutoDTO
            {
                Nome = novoProduto.Nome,
                Descricao = novoProduto.Descricao,
                imagemUrl = novoProduto.ImagemURL,
                Preco = novoProduto.Preco
            };
            return novoProdutoDTO;
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
            produtoEncontrado.ImagemURL = produto.imagemUrl;
            dbContext.SaveChanges();
            return true;
        }

        public async Task<Produto> UploadImage(string id, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                throw new ArgumentException("Arquivo inválido ou vazio.");
            }

            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produto is null)
            {
                throw new ProdutoInexistente("Produto inexistente.");
            }

            string extensaoArquivo = arquivo.FileName.Substring(arquivo.FileName.LastIndexOf(".") + 1);

            string nomePasta = "produtos";
            string caminhoDaPastaDeUploads = Path.Combine("wwwroot", nomePasta);
            Directory.CreateDirectory(caminhoDaPastaDeUploads);

            string nomeDoArquivo = $"{id}.{extensaoArquivo}";
            string caminhoDoArquivo = Path.Combine(caminhoDaPastaDeUploads, nomeDoArquivo);

            using (var stream = new FileStream(caminhoDoArquivo, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            string urlServidor = servicoUrl.ObterUrlServidor();

            string imagemUrl = $"{urlServidor}/{nomePasta}/{nomeDoArquivo}";

            produto.ImagemURL = imagemUrl;
            dbContext.SaveChanges();

            return produto;
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

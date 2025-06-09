using Microsoft.AspNetCore.Http;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using static SoftGallery.Dominio.DTO.ProdutoDTO;

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
                id = p.Id,
                nome = p.Nome,
                preco = p.Preco,
                imagemUrl = p.ImagemURL ?? string.Empty
            }).ToList();

            return produtosDTO;
        }

        public Produto? RetornaProduto(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);
            return produto;
        }

        public Produto CriarProduto(ProdutoDTOListagem produto)
        {
            Produto novoProduto = new Produto(produto.nome, produto.preco, produto.descricao, produto.imagemUrl);

            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();
            ProdutoDTOListagem novoProdutoDTO = new ProdutoDTOListagem
            {
                nome = novoProduto.Nome,
                descricao = novoProduto.Descricao,
                imagemUrl = novoProduto.ImagemURL,
                preco = novoProduto.Preco
            };
            return novoProduto;
        }

        public bool EditarProduto(string id, ProdutoDTOListagem produto)
        {
            Produto? produtoEncontrado =
                dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return false;
            }

            produtoEncontrado.Nome = produto.nome;
            produtoEncontrado.Descricao = produto.descricao;
            produtoEncontrado.Preco = produto.preco;
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
                throw new RecursoNaoEncontradoException("Produto inexistente.");
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

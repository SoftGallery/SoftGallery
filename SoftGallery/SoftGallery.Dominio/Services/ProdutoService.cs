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

        /*public List<Produto> ObterProdutosRecomendados(string? clienteId, int limite = 5)
        {
            if (!string.IsNullOrEmpty(clienteId))
            {
                // Produtos que o cliente já comprou
                var produtosDoCliente = dbContext.Pedidos
                    .Where(p => p.Cliente.Id == clienteId)
                    .SelectMany(p => p.Produtos)
                    .Select(p => p.Id)
                    .Distinct()
                    .ToList();

                if (produtosDoCliente.Any())
                {
                    // Baseado nos produtos do cliente, calcular produtos similares
                    return ObterProdutosSimilares(produtosDoCliente, limite);
                }
            }

            // Se clienteId não informado ou cliente sem histórico, pegar produtos mais pedidos

            // Contar produtos mais pedidos
            var produtosMaisPedidos = dbContext.Pedidos
                .SelectMany(p => p.Produtos)
                .GroupBy(p => p.Id)
                .Select(g => new
                {
                    ProdutoId = g.Key,
                    Quantidade = g.Count()
                })
                .OrderByDescending(x => x.Quantidade)
                .Take(limite)
                .ToList();

            if (produtosMaisPedidos.Any())
            {
                var produtosIds = produtosMaisPedidos.Select(x => x.ProdutoId).ToList();
                return dbContext.Produtos
                    .Where(p => produtosIds.Contains(p.Id))
                    .ToList();
            }

            // Se não há produtos mais pedidos (ex: base vazia), retorna uma lista padrão (exemplo primeiros produtos)
            return dbContext.Produtos
                .Take(limite)
                .ToList();
        }

        // Reutilizando o método de similaridade que já passei antes:
        public List<Produto> ObterProdutosSimilares(List<string> produtosSelecionadosIds, int limite = 5)
        {
            var produtosSelecionados = produtosSelecionadosIds.ToHashSet();

            var pedidosComProdutos = dbContext.Pedidos
                .Include(p => p.Produtos)
                .Where(p => p.Produtos.Any(prod => produtosSelecionados.Contains(prod.Id)))
                .ToList();

            var produtoParaPedidos = new Dictionary<string, HashSet<string>>();

            foreach (var pedido in pedidosComProdutos)
            {
                foreach (var produto in pedido.Produtos)
                {
                    if (!produtoParaPedidos.ContainsKey(produto.Id))
                        produtoParaPedidos[produto.Id] = new HashSet<string>();

                    produtoParaPedidos[produto.Id].Add(pedido.Id);
                }
            }

            var similaridades = new Dictionary<string, double>();

            foreach (var produtoId in produtoParaPedidos.Keys)
            {
                if (produtosSelecionados.Contains(produtoId))
                    continue;

                double maxSimilaridade = 0;

                foreach (var selecionadoId in produtosSelecionados)
                {
                    if (!produtoParaPedidos.ContainsKey(selecionadoId))
                        continue;

                    var pedidosProduto = produtoParaPedidos[produtoId];
                    var pedidosSelecionado = produtoParaPedidos[selecionadoId];

                    int intersecao = pedidosProduto.Intersect(pedidosSelecionado).Count();
                    int uniao = pedidosProduto.Union(pedidosSelecionado).Count();

                    double jaccard = uniao == 0 ? 0 : (double)intersecao / uniao;

                    if (jaccard > maxSimilaridade)
                        maxSimilaridade = jaccard;
                }

                if (maxSimilaridade > 0)
                    similaridades[produtoId] = maxSimilaridade;
            }

            var produtosSimilaresIds = similaridades
                .OrderByDescending(kv => kv.Value)
                .Take(limite)
                .Select(kv => kv.Key)
                .ToList();

            var produtosSimilares = dbContext.Produtos
                .Where(p => produtosSimilaresIds.Contains(p.Id))
                .ToList();

            return produtosSimilares;
        }*/



    }
}

using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SoftGallery.Dominio.Exceptions;
using static SoftGallery.Dominio.DTO.CampanhaDTO;
using static SoftGallery.Dominio.DTO.ProdutoDTO;

namespace SoftGallery.Dominio.Services
{
    public class CampanhaService
    {
        private readonly SoftGalleryDominioDbContext dbContext;
        private readonly UrlServico servicoUrl;

        public CampanhaService(SoftGalleryDominioDbContext dbContext, UrlServico servicoUrl)
        {
            this.dbContext = dbContext;
            this.servicoUrl = servicoUrl;
        }

        public List<ResumoCampanhaDTO> ListarCampanhas(bool somenteAtivas = false)
        {
            IQueryable<Campanha> query = dbContext
                                    .Campanhas
                                    .Include(c => c.Produtos)
                                    .AsQueryable();

            if (somenteAtivas)
            {
                query = query.Where(c => c.DataInicio <= DateTime.Now && c.DataFim >= DateTime.Now);
            }

            List<ResumoCampanhaDTO> campanhaDTO = query.Select(c => new ResumoCampanhaDTO
            {
                id = c.Id,
                nome = c.Nome,
                imagemURL = c.ImagemURL ?? string.Empty,
            }).ToList();


            return campanhaDTO;
        }

        public ProdutosCampanhaDTO RetornarProdutosCampanha(string id)
        {
            var campanha = dbContext
                .Campanhas
                .Include(c => c.Produtos)
                .FirstOrDefault(c => c.Id == id);

            if (campanha == null)
                return new ProdutosCampanhaDTO();

            ProdutosCampanhaDTO produtosCampanha = new ProdutosCampanhaDTO
            {
                produtos = campanha.Produtos.Select(p => new ResumoProdutoDTO
                {
                    id = p.Id,
                    nome = p.Nome,
                    preco = p.Preco,
                    imagemUrl = p.ImagemURL ?? string.Empty
                }).ToList()
            };

            return produtosCampanha;
        }

        public Campanha RetornarCampanha(string id)
        {
            var campanha = dbContext
                .Campanhas
                .Include(c => c.Produtos)
                .FirstOrDefault(c => c.Id == id);

            if (campanha == null)
                throw new RecursoNaoEncontradoException("Campanha não encontrada.");

            return campanha;
        }


        public Campanha CriarCampanha(CampanhaDTOInput campanhaDto)
        {
            var produtos = dbContext.Produtos
                .Where(p => campanhaDto.produtoIds.Contains(p.Id))
                .ToList();

            var novaCampanha = new Campanha(
                campanhaDto.nome,
                campanhaDto.dataInicio,
                campanhaDto.dataFim,
                produtos
            );

            dbContext.Campanhas.Add(novaCampanha);
            dbContext.SaveChanges();

            return novaCampanha;
        }

        public async Task<Campanha> UploadImage(string id, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                throw new ArgumentException("Arquivo inválido ou vazio.");
            }

            Campanha? campanha = dbContext
                .Campanhas
                .FirstOrDefault(p => p.Id == id);

            if (campanha is null)
            {
                throw new RecursoNaoEncontradoException("Campanha inexistente.");
            }

            string extensaoArquivo = arquivo.FileName.Substring(arquivo.FileName.LastIndexOf(".") + 1);

            string nomePasta = "campanhas";
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

            campanha.ImagemURL = imagemUrl;
            dbContext.SaveChanges();

            return campanha;
        }

        public bool EditarCampanha(string id, CampanhaDTOInput campanhaDto)
        {
            var campanha = dbContext.Campanhas
                .Include(c => c.Produtos)
                .FirstOrDefault(c => c.Id == id);

            if (campanha == null)
                return false;

            campanha.Nome = campanhaDto.nome;
            campanha.DataInicio = campanhaDto.dataInicio;
            campanha.DataFim = campanhaDto.dataFim;

            campanha.Produtos = dbContext.Produtos
                .Where(p => campanhaDto.produtoIds.Contains(p.Id))
                .ToList();

            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCampanha(string id)
        {
            var campanha = dbContext.Campanhas.FirstOrDefault(c => c.Id == id);
            if (campanha == null)
                return false;

            dbContext.Campanhas.Remove(campanha);
            dbContext.SaveChanges();
            return true;
        }
    }
}

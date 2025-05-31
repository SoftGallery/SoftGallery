using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.DTO;
using Microsoft.EntityFrameworkCore;

namespace SoftGallery.Dominio.Services
{
    public class CampanhaService
    {
        private readonly SoftGalleryDominioDbContext dbContext;

        public CampanhaService(SoftGalleryDominioDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            IQueryable<ResumoCampanhaDTO> campanhasDto = query.Select(c => new ResumoCampanhaDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                DataInicio = c.DataInicio,
                DataFim = c.DataFim
            });

            return campanhasDto.ToList();
        }

        public ProdutosCampanhaDTO RetornarCampanha(string id)
        {
            var campanha = dbContext
                .Campanhas
                .Include(c => c.Produtos)
                .FirstOrDefault(c => c.Id == id);

            if (campanha == null)
                return new ProdutosCampanhaDTO();

            ProdutosCampanhaDTO produtosCampanha = new ProdutosCampanhaDTO
            {
                Produtos = campanha.Produtos.Select(p => new ResumoProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                }).ToList()
            };

            return produtosCampanha;
        }

        public Campanha CriarCampanha(CampanhaDTO campanhaDto)
        {
            var produtos = dbContext.Produtos
                .Where(p => campanhaDto.ProdutoIds.Contains(p.Id))
                .ToList();

            var novaCampanha = new Campanha(
                campanhaDto.Nome,
                campanhaDto.DataInicio,
                campanhaDto.DataFim,
                produtos
            );

            dbContext.Campanhas.Add(novaCampanha);
            dbContext.SaveChanges();

            return novaCampanha;
        }

        public bool EditarCampanha(string id, CampanhaDTO campanhaDto)
        {
            var campanha = dbContext.Campanhas
                .Include(c => c.Produtos)
                .FirstOrDefault(c => c.Id == id);

            if (campanha == null)
                return false;

            campanha.Nome = campanhaDto.Nome;
            campanha.DataInicio = campanhaDto.DataInicio;
            campanha.DataFim = campanhaDto.DataFim;

            campanha.Produtos = dbContext.Produtos
                .Where(p => campanhaDto.ProdutoIds.Contains(p.Id))
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

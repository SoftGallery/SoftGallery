using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Models;

namespace SoftGallery.Dominio.Services
{
    public class LojaService
    {
        private readonly SoftGalleryDominioDbContext dbContext;

        public LojaService(SoftGalleryDominioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Loja? ObterConfiguracao()
        {
            return dbContext.Loja.FirstOrDefault();
        }

        public void UpsertConfiguracao(LojaDTO dto)
        {
            var config = dbContext.Loja.FirstOrDefault();

            if (config == null)
            {
                // Cadastrar nova
                config = new Loja(dto.Nome, dto.Descricao, dto.Endereco, dto.Email)
                {
                    Whatsapp = dto.Whatsapp,
                    Facebook = dto.Facebook,
                    Instagram = dto.Instagram,
                    TikTok = dto.TikTok,
                    X = dto.X
                };

                dbContext.Loja.Add(config);
            }
            else
            {
                config.Nome = dto.Nome;
                config.Descricao = dto.Descricao;
                config.Endereco = dto.Endereco;
                config.Email = dto.Email;
                config.Whatsapp = dto.Whatsapp;
                config.Facebook = dto.Facebook;
                config.Instagram = dto.Instagram;
                config.TikTok = dto.TikTok;
                config.X = dto.X;
            }

            dbContext.SaveChanges();
        }
    }
}

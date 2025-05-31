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
                config = new Loja(dto.nome, dto.descricao, dto.endereco, dto.email)
                {
                    Whatsapp = dto.whatsapp,
                    Facebook = dto.facebook,
                    Instagram = dto.instagram,
                    TikTok = dto.tikTok,
                    X = dto.x
                };

                dbContext.Loja.Add(config);
            }
            else
            {
                config.Nome = dto.nome;
                config.Descricao = dto.descricao;
                config.Endereco = dto.endereco;
                config.Email = dto.email;
                config.Whatsapp = dto.whatsapp;
                config.Facebook = dto.facebook;
                config.Instagram = dto.instagram;
                config.TikTok = dto.tikTok;
                config.X = dto.x;
            }

            dbContext.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Http;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Exceptions;
using SoftGallery.Dominio.Models;
using static SoftGallery.Dominio.DTO.LojaDTO;

namespace SoftGallery.Dominio.Services
{
    public class LojaService
    {
        private readonly SoftGalleryDominioDbContext dbContext;
        private readonly UrlServico servicoUrl;

        public LojaService(SoftGalleryDominioDbContext dbContext, UrlServico servicoUrl)
        {
            this.dbContext = dbContext;
            this.servicoUrl = servicoUrl;
        }

        public Loja? ObterConfiguracao()
        {
            return dbContext.Loja.FirstOrDefault();
        }

        public void UpsertConfiguracao(LojaDTOInput dto)
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
                    X = dto.x,
                    ImagemURL = dto.imagemUrl
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
                config.ImagemURL = dto.imagemUrl;
            }

            dbContext.SaveChanges();
        }
        public async Task<Loja> UploadImage(string id, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                throw new ArgumentException("Arquivo inválido ou vazio.");
            }

            Loja? loja = dbContext
                .Loja
                .FirstOrDefault(p => p.Id == id);

            if (loja is null)
            {
                throw new RecursoNaoEncontradoException("Loja inexistente.");
            }

            string extensaoArquivo = arquivo.FileName.Substring(arquivo.FileName.LastIndexOf(".") + 1);

            string nomePasta = "loja";
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

            loja.ImagemURL = imagemUrl;
            dbContext.SaveChanges();

            return loja;
        }
    }
}

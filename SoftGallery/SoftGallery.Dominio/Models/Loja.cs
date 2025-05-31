using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftGallery.Dominio.Models
{
    public class Loja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; }

        public string? Endereco { get; set; }
        public string? ImagemURL { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Whatsapp { get; set; }

        [Url]
        public string? Facebook { get; set; }

        [Url]
        public string? Instagram { get; set; }

        [Url]
        public string? TikTok { get; set; }

        [Url]
        public string? X { get; set; }

        public Loja(
            string nome,
            string descricao,
            string? endereco = null,
            string? email = null,
            string? whatsapp = null,
            string? facebook = null,
            string? instagram = null,
            string? tiktok = null,
            string? x = null,
            string? imagemUrl = null
        )
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Endereco = endereco;
            this.Email = email;
            this.Whatsapp = whatsapp;
            this.Facebook = facebook;
            this.Instagram = instagram;
            this.TikTok = tiktok;
            this.X = x;
            this.ImagemURL = imagemUrl;
        }

        private Loja() { }
    }
}

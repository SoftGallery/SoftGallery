using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftGallery.Dominio.Models
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemURL { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco, string? descricao = null, string? imagemUrl = null)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Descricao = descricao;
            this.ImagemURL = imagemUrl;
        }

        private Produto() { }
    }
}

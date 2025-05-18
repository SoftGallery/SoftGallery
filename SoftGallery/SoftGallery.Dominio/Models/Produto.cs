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
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }

        private Produto() { }
    }
}

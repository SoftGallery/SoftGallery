using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SoftGallery.Dominio.Models
{
    public class Campanha
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string? ImagemURL { get; set; }
        public List<Produto> Produtos { get; set; }

        [NotMapped]
        public bool Active
        {
            get
            {
                var hoje = DateTime.Now;
                return hoje >= DataInicio && hoje <= DataFim;
            }
        }

        public Campanha(string nome, DateTime dataInicio, DateTime dataFim, List<Produto>? produtos = null, string? imageUrl = null)
        {
            this.Nome = nome;
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
            this.Produtos = produtos ?? [];
            this.ImagemURL = imageUrl;
        }

        private Campanha() { }
    }
}

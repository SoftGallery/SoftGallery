namespace SoftGallery.Dominio.DTO
{
    public class CampanhaDTO
    {
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public List<string> ProdutoIds { get; set; }
    }
}

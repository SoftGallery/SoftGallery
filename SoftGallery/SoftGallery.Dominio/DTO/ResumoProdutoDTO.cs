namespace SoftGallery.Dominio.DTO
{
    public class ResumoProdutoDTO
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string? imagemUrl { get; set; }
        public decimal preco { get; set; }
    }
}

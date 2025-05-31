namespace SoftGallery.Dominio.DTO
{
    public class ResumoProdutoDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string? imagemUrl { get; set; }
        public decimal Preco { get; set; }
    }
}

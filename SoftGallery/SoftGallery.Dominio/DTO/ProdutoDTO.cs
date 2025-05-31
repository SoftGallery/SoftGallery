namespace SoftGallery.Dominio.DTO
{
    public class ProdutoDTO
    {
        public string nome { get; set; }
        public string? descricao { get; set; }
        public string? imagemUrl { get; set; }
        public decimal preco { get; set; }
    }
}

namespace SoftGallery.Dominio.DTO
{
    public class ProdutoDTO
    {
        public class ProdutoDTOListagem
        {
            public string nome { get; set; }
            public string? descricao { get; set; }
            public string? imagemUrl { get; set; }
            public decimal preco { get; set; }
        }

        public class ResumoProdutoDTO
        {
            public string id { get; set; }
            public string nome { get; set; }
            public string? imagemUrl { get; set; }
            public decimal preco { get; set; }
        }

    }
}

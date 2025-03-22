namespace SoftGallery.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal ValorVenda { get; set; }

        public string DescricaoDetalhada { get; set; }

        public List<Imagem> Imagens { get; set; }

        public List<string> Variacoes { get; set; }

        public List<Secao> Secoes { get; set; }

    }

    public class Imagem
    {
        public string UrlImagem { get; set; }
        public string UrlThumb { get; set; }
        public bool Principal { get; set; }
    }
}

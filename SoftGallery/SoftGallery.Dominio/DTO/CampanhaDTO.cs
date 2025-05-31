using static SoftGallery.Dominio.DTO.ProdutoDTO;

namespace SoftGallery.Dominio.DTO
{
    public class CampanhaDTO
    {
        public class CampanhaDTOInput {
            public string nome { get; set; }

            public DateTime dataInicio { get; set; }

            public DateTime dataFim { get; set; }

            public List<string> produtoIds { get; set; }
        }

        public class ResumoCampanhaDTO
        {
            public string id { get; set; }
            public string nome { get; set; }
            public string? imagemURL { get; set; }
        }

        public class ProdutosCampanhaDTO
        {
            public List<ResumoProdutoDTO> produtos { get; set; }
        }
    }
}

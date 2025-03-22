using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftGallery.Dominio.Entidades
{
    public class Secao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativo { get; set; }
        public int Ordem { get; set; }
        public string Banner { get; set; }
        public List<Secao> SubSecao { get; set; }
        public List<int> IdProdutos { get; set; }
    }
}

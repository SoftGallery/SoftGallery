using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftGallery.Dominio.Exceptions
{
    public class ProdutoInexistente : Exception
    {
        public ProdutoInexistente(string message) : base(message) { }
    }
}

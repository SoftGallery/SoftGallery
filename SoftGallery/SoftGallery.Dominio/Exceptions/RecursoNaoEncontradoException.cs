using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftGallery.Dominio.Exceptions
{
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException(string message) : base(message) { }
    }
}

using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftGallery.Dominio.Servicos
{
    public class SecaoServico
    {
        private readonly ISessionFactory session;

        public SecaoServico(ISessionFactory session)
        {
            this.session = session;
        }

        public List<Entidades.Secao> Listar()
        {
            session.Query<S
        }
    }
}

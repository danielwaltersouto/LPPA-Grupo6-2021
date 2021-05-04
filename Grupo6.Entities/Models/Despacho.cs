using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class Despacho : IdentityBase
    {
        public int IdDespacho { get; set; }
        public string Letra { get; set; }
        public int Numero { get; set; }
        public int IdEstadoPedido { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
}

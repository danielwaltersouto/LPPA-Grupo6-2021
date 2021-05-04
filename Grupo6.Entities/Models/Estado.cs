using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class Estado
    {
        public int IdEstadoPedido { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Despacho> Despacho { get; set; }
    }
}

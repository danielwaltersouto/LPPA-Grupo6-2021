using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class Estado : IdentityBase
    {
        public int IdEstadoPedido { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Despacho> Despacho { get; set; }
    }
}

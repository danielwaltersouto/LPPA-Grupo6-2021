using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class EstadoPedido : IdentityBase
    {
        public string Descripcion { get; set; }

        public virtual ICollection<Despacho> Despacho { get; set; }
    }
}

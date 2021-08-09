using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class CategoriaProducto : IdentityBase
    {
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}

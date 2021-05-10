using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class CategoriaProducto : IdentityBase
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class ItemCarrito : IdentityBase
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

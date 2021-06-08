using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class ItemCarrito : IdentityBase
    {
        [ForeignKey("Carrito"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPedido { get; set; }
        [ForeignKey("Producto"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

namespace Grupo6.Entities.Models
{
    public class ItemCarrito : IdentityBase
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class DetalleFactura : IdentityBase
    {
        [ForeignKey("Factura"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NroFactura { get; set; }
        [ForeignKey("Producto"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

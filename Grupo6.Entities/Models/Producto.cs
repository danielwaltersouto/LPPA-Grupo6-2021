using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Producto : IdentityBase
    {
        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        [ForeignKey("CategoriaProducto"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategoriaProducto { get; set; }
        public byte[] FotoProducto { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual ICollection<ItemCarrito> ItemCarrito { get; set; }
    }
}

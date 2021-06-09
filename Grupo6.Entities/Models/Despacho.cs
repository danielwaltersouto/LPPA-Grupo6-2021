using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Despacho : IdentityBase
    {
        public int IdDespacho { get; set; }
        [ForeignKey("Factura"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NroFactura { get; set; }
        [ForeignKey("EstadoPedido"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEstadoPedido { get; set; }

        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual Factura Factura { get; set; }
    }
}


namespace Grupo6.Entities.Models
{
    public class Despacho : IdentityBase
    {
        public int FacturaId { get; set; }
        public int EstadoPedidoId { get; set; }

        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual Factura Factura { get; set; }
    }
}


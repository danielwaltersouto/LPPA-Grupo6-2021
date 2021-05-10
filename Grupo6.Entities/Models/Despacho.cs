namespace Grupo6.Entities.Models
{
    public class Despacho : IdentityBase
    {
        public int IdDespacho { get; set; }
        public int NroFactura { get; set; }
        public int IdEstadoPedido { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Factura Factura { get; set; }
    }
}


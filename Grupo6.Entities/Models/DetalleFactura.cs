using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class DetalleFactura
    {
        public string Letra { get; set; }
        public int Numero { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

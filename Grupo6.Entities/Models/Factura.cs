using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class Factura
    {
        public Factura()
        {
            this.FechaInicio = DateTime.Now;
        }

        public string Letra { get; set; }
        public int Numero { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }

        public virtual ICollection<Despacho> Despacho { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

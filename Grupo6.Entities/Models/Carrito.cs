using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class Carrito
    {
        public Carrito()
        {
            this.Creado = DateTime.Now;
        }

        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ItemCarrito ItemCarrito { get; set; }
    }
}

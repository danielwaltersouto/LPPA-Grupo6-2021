using System;
using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class Carrito : IdentityBase
    {
        public Carrito()
        {
            this.Creado = DateTime.Now;
            this.Modificado = DateTime.Now;
        }
        public int UsuarioId { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ItemCarrito> ItemCarrito { get; set; }
    }
}

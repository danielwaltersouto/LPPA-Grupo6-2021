using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Carrito: IdentityBase
    {
        public Carrito()
        {
            this.Creado = DateTime.Now;
        }

        public int IdPedido { get; set; }
        [ForeignKey("Usuario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ItemCarrito>  ItemCarrito { get; set; }
    }
}

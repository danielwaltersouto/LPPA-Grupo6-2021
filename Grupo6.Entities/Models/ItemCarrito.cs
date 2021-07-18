using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Grupo6.Entities.Models
{
    public class ItemCarrito : IdentityBase
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        [XmlIgnore]
        public virtual Carrito Carrito { get; set; }

        [XmlIgnore]
        public virtual Producto Producto { get; set; }
    }
}

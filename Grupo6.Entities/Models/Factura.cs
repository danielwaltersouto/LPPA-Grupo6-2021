using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Factura : IdentityBase
    {
        public Factura()
        {
            FechaInicio = DateTime.Now;
        }
        public int NroFactura { get; set; }
        [ForeignKey("Usuario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public string TipoFactura { get; set; }
        public virtual ICollection<Despacho> Despacho { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Usuario : IdentityBase
    {
        public Usuario()
        {
            FechaAlta = DateTime.Now;
            Bloqueo = 0;
            EmailConfirmed = false;
        }
        public int IdUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        [ForeignKey("CategoriaFiscal"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategoriaFiscal { get; set; }
        public string NombreWeb { get; set; }
        public string Password { get; set; }
        public int Bloqueo { get; set; }
        [ForeignKey("Rol"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public string UserToken { get; set; }

        public virtual ICollection<Carrito> Carrito { get; set; }
        public virtual CategoriaFiscal CategoriaFiscal { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual Rol Rol { get; set; }
    }
}

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

        [Display(Name = "Categoria Fiscal")]
        public int IdCategoriaFiscal { get; set; }
       
        [Display(Name = "Usuario WEB")]

   
        public int CategoriaFiscalId { get; set; }
        public string NombreWeb { get; set; }
        public string Password { get; set; }
        public int Bloqueo { get; set; }
        public int IntentosLogin { get; set; }
        public int IdRol { get; set; }
        
        
        [Required(ErrorMessage = "Se requiere Nombre")]
        [MaxLength(30)]
        public string Nombre { get; set; }

    
        public int RolId { get; set; }

     
        [Required(ErrorMessage = "Se requiere Apellido")]
        [MaxLength(30)]
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }
       
        public DateTime FechaAlta { get; set; }

        public int Telefono { get; set; }
        public string Email { get; set; }
        
        [NotMapped]
        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        [Display(Name = "Re-Ingreso Email")]
        [Compare(nameof(Email), ErrorMessage = "Email no Coincide")]
       
        public bool EmailConfirmed { get; set; }
        public string UserToken { get; set; }

        public virtual ICollection<Carrito> Carrito { get; set; }
        public virtual CategoriaFiscal CategoriaFiscal { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual Rol Rol { get; set; }
    }
}

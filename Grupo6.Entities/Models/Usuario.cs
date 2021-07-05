using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
      
      
        [Display(Name = "Usuario WEB")]
        public string NombreWeb { get; set; }
        
        
        public DateTime FechaAlta { get; set; }
       
        
        [ForeignKey("CategoriaFiscal"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Categoria Fiscal")]
        public int IdCategoriaFiscal { get; set; }
       

        [Required(ErrorMessage = "Se requiere Nombre")]
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere Apellido")]
        [MaxLength(30)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se requiere Documento")]
 
        public int Documento { get; set; }

        [Required(ErrorMessage = "Se requiere fecha")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
       
        public int Telefono { get; set; }

       
        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Password no Coincide")]
        [Required(ErrorMessage = "Se requiere Password")]
        [Display(Name = "Re Ingrese Password")]
        [DataType(DataType.Password)]
        public string Password_ { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        public string Email { get; set; }

        [NotMapped]
        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        [Display(Name = "Re-Ingreso Email")]
        [Compare(nameof(Email), ErrorMessage = "Email no Coincide")]
        public string Email_ { get; set; }

        public bool EmailConfirmed { get; set; }

        public int Bloqueo { get; set; }

        public int IntentosLogin { get; set; }

        public string UserToken { get; set; }
        
        [ForeignKey("Rol"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRol { get; set; }
   
    

        public virtual ICollection<Carrito> Carrito { get; set; }
        public virtual CategoriaFiscal CategoriaFiscal { get; set; }
        public virtual ICollection<Direccion> Direccion { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual Rol Rol { get; set; }
    }
}


  
       



 

   


        



  


        

        




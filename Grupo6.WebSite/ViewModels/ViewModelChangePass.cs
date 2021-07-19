using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grupo6.WebSite.ViewModels
{
    public class ViewModelChangePass
    {

        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password no Coincide")]
        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password_ { get; set; }





    }
}
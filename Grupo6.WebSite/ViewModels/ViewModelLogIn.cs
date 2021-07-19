using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Grupo6.WebSite.ViewModels
{
    public class ViewModelLogIn
    {

        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        public string Email { get; set; }

    }
}
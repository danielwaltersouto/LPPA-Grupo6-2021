using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo6.Entities.Models;
using Grupo6.Data.Services;




namespace Grupo6.Services
{
    public class ValidarIngreso
    {
        public static bool Validar(Usuario model)
        {
            bool ValidadorIngreso = false;


            string Password = model.Password;
          

            var db = new BaseDataService<Usuario>();
          
            var Ouser= db.Get((Usuario usuario) => usuario.Email == model.Email).First();

            string Password2 = Ouser.Password;


            ValidadorIngreso = Encriptador.Validar(Password,Password2) ;

            if (ValidadorIngreso == false)
            {

                string uToken = Ouser.UserToken;

                ValidadorIngreso = Encriptador.Validar(Password, uToken);

            }


      
            return ValidadorIngreso ;


        }


           
        }


    }


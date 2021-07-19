using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Linq;




namespace Grupo6.Services
{
    public class ValidarIngreso
    {
        public static bool Validar(Usuario model, ref string rol)
        {
            bool ValidadorIngreso = false;
            string Password = model.Password;
            var db = new BaseDataService<Usuario>();
            var Ouser = db.Get((Usuario usuario) => usuario.Email == model.Email).FirstOrDefault();

            if (Ouser == null)
            {
                return false;
            }

            string Password2 = Ouser.Password;
            ValidadorIngreso = Encriptador.Validar(Password, Password2);
            rol = Ouser.Rol.Nombre;
            if (ValidadorIngreso == false)
            {

                string uToken = Ouser.UserToken;

                ValidadorIngreso = Encriptador.Validar(Password, uToken);

            }
            return ValidadorIngreso;
        }
    }
}


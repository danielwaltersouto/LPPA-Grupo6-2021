using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using Grupo6.Services;


namespace Grupo6.Business
{
    public class BizUsuario
    {
        public void Agregar(Usuario usuario)
        {
            var db = new BaseDataService<Usuario>();



            usuario.RolId = 2;
            usuario.Password = Encriptador.Encriptar(usuario.Password);
            usuario.Password_ = Encriptador.Encriptar(usuario.Password_);
            usuario.NombreWeb = usuario.Nombre + " " + usuario.Apellido;

            db.Create(usuario);

        }

        public List<Usuario> TraerTodos()
        {
            var db = new BaseDataService<Usuario>();
            var lista = db.Get();
            return lista;
        }

        public Usuario TraerPorId(int id)
        {
            var db = new BaseDataService<Usuario>();
            return db.GetById(id);
        }




        public Usuario TraerPorEmail(string email)
        {
            var db = new BaseDataService<Usuario>();
            return db.Get().SingleOrDefault(u => u.Email == email);
        }

        public void Eliminar(Usuario usuario)
        {
            var db = new BaseDataService<Usuario>();
            db.Delete(usuario);
        }
        public void Eliminar(int idUsuario)
        {
            var db = new BaseDataService<Usuario>();
            db.Delete(idUsuario);
        }

        public void Actualizar(Usuario usuario)
        {

            var db = new BaseDataService<Usuario>();
        

            db.Update(usuario);
        }


        public void Actualizar_profile(Usuario usuario)
        {

             var db = new BaseDataService<Usuario>();
            
           
            Usuario oldUsuario = TraerPorId(usuario.Id);
          

            oldUsuario.Nombre = usuario.Nombre;
            oldUsuario.Apellido = usuario.Apellido;
            oldUsuario.Documento = usuario.Documento;
            oldUsuario.Email_ = oldUsuario.Email;
            oldUsuario.Password_ = oldUsuario.Password;
           
            
       

            db.Update(oldUsuario);
        }





        public void ActualizarPorEmail(string dato, string email)
        {
            var db = new BaseDataService<Usuario>();
            Usuario Busuario = db.Get((Usuario usuario) => usuario.Email == email).First();
            string clave = dato;
            string SHAClave = Encriptador.Encriptar(clave);
            Busuario.Password = SHAClave;
            Busuario.Password_ = SHAClave;
            Busuario.Email_ = email;
            string Titulo = "Cambio de Contraseña";
            string Cuerpo = Busuario.Nombre + " " + Busuario.Apellido + " Tu Clave se Cambio con Exito";
            Busuario.UserToken = SHAClave;
            db.Update(Busuario);
            CorreoElectronico.EnviarMail(Titulo, Cuerpo, Busuario.Email);


        }


        public void RecuperarPorEmail(string dato, string email)
        {
            var db = new BaseDataService<Usuario>();
            Usuario Busuario = db.Get((Usuario usuario) => usuario.Email == email).First();
            string clave = dato;
            string SHAClave = Encriptador.Encriptar(clave);
            Busuario.Password = SHAClave;
            Busuario.Password_ = SHAClave;
            Busuario.Email_ = email;
            string Titulo = "Recupero de Contraseña";
            string Cuerpo = Busuario.Nombre + " " + Busuario.Apellido + " Tu Clave se Cambio con Exito a  "+dato;
            Busuario.UserToken = SHAClave;
            db.Update(Busuario);
            CorreoElectronico.EnviarMail(Titulo, Cuerpo, Busuario.Email);


        }






    }
}

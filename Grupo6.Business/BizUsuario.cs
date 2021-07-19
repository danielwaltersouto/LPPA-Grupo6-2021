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
    }
}

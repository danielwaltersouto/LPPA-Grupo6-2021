using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizUsuario
    {
        public void Agregar(Usuario usuario)
        {
            var db = new BaseDataService<Usuario>();
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

        public void Eliminar(Usuario usuario)
        {
            var db = new BaseDataService<Usuario>();
            db.Delete(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            var db = new BaseDataService<Usuario>();
            db.Update(usuario);
        }
    }
}

using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizDireccion
    {
        public void Agregar(Direccion direccion)
        {
            var db = new BaseDataService<Direccion>();
            db.Create(direccion);

        }

        public List<Direccion> TraerTodos()
        {
            var db = new BaseDataService<Direccion>();
            var lista = db.Get();
            return lista;
        }

        public Direccion TraerPorId(int id)
        {
            var db = new BaseDataService<Direccion>();
            return db.GetById(id);
        }


        public List<Direccion> TraerTodos_id(int id)
        {
            var db = new BaseDataService<Direccion>();
            var lista = db.Get(x => x.UsuarioId == id);
            return lista;
        }
            public void Eliminar(Direccion direccion)
        {
            var db = new BaseDataService<Direccion>();
            db.Delete(direccion);
        }

        public void Actualizar(Direccion direccion)
        {
            var db = new BaseDataService<Direccion>();
            db.Update(direccion);
        }
    }
}

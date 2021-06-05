using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizEstado
    {
        public void Agregar(Estado estado)
        {
            var db = new BaseDataService<Estado>();
            db.Create(estado);

        }

        public List<Estado> TraerTodos()
        {
            var db = new BaseDataService<Estado>();
            var lista = db.Get();
            return lista;
        }

        public Estado TraerPorId(int id)
        {
            var db = new BaseDataService<Estado>();
            return db.GetById(id);
        }

        public void Eliminar(Estado estado)
        {
            var db = new BaseDataService<Estado>();
            db.Delete(estado);
        }

        public void Actualizar(Estado estado)
        {
            var db = new BaseDataService<Estado>();
            db.Update(estado);
        }
    }
}

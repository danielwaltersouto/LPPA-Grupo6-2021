using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizDespacho
    {
        public void Agregar(Despacho despacho)
        {
            var db = new BaseDataService<Despacho>();
            db.Create(despacho);

        }

        public List<Despacho> TraerTodos()
        {
            var db = new BaseDataService<Despacho>();
            var lista = db.Get();
            return lista;
        }

        public Despacho TraerPorId(int id)
        {
            var db = new BaseDataService<Despacho>();
            return db.GetById(id);
        }

        public void Eliminar(Despacho despacho)
        {
            var db = new BaseDataService<Despacho>();
            db.Delete(despacho);
        }

        public void Actualizar(Despacho despacho)
        {
            var db = new BaseDataService<Despacho>();
            db.Update(despacho);
        }
    }
}

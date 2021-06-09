using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizCarrito
    {
        public void Agregar(Carrito carrito)
        {
            var db = new BaseDataService<Carrito>();
            db.Create(carrito);

        }

        public List<Carrito> TraerTodos()
        {
            var db = new BaseDataService<Carrito>();
            var lista = db.Get();
            return lista;
        }

        public Carrito TraerPorId(int id)
        {
            var db = new BaseDataService<Carrito>();
            return db.GetById(id);
        }

        public void Eliminar(Carrito carrito)
        {
            var db = new BaseDataService<Carrito>();
            db.Delete(carrito);
        }

        public void Actualizar(Carrito carrito)
        {
            var db = new BaseDataService<Carrito>();
            db.Update(carrito);
        }
    }
}

using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizProducto
    {
        public void Agregar(Producto producto)
        {
            var db = new BaseDataService<Producto>();
            db.Create(producto);

        }

        public List<Producto> TraerTodos()
        {
            var db = new BaseDataService<Producto>();
            var lista = db.Get();
            return lista;
        }

        public Producto TraerPorId(int id)
        {
            var db = new BaseDataService<Producto>();
            return db.GetById(id);
        }

        public void Eliminar(Producto producto)
        {
            var db = new BaseDataService<Producto>();
            db.Delete(producto);
        }
        public void Eliminar(int idProducto)
        {
            var db = new BaseDataService<Producto>();
            db.Delete(idProducto);
        }

        public void Actualizar(Producto producto)
        {
            var db = new BaseDataService<Producto>();
            db.Update(producto);
        }
    }
}

using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizCategoriaProducto
    {
        public void Agregar(CategoriaProducto categoriaProducto)
        {
            var db = new BaseDataService<CategoriaProducto>();
            db.Create(categoriaProducto);

        }

        public List<CategoriaProducto> TraerTodos()
        {
            var db = new BaseDataService<CategoriaProducto>();
            var lista = db.Get();
            return lista;
        }

        public CategoriaProducto TraerPorId(int id)
        {
            var db = new BaseDataService<CategoriaProducto>();
            return db.GetById(id);
        }

        public void Eliminar(CategoriaProducto categoriaProducto)
        {
            var db = new BaseDataService<CategoriaProducto>();
            db.Delete(categoriaProducto);
        }

        public void Eliminar(int idCategoriaProducto)
        {
            var db = new BaseDataService<CategoriaProducto>();
            db.Delete(idCategoriaProducto);
        }

        public void Actualizar(CategoriaProducto categoriaProducto)
        {
            var db = new BaseDataService<CategoriaProducto>();
            db.Update(categoriaProducto);
        }
    }
}

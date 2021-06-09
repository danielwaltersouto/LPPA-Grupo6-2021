using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizCategoriaFiscal
    {
        public void Agregar(CategoriaFiscal categoriaFiscal)
        {
            var db = new BaseDataService<CategoriaFiscal>();
            db.Create(categoriaFiscal);

        }

        public List<CategoriaFiscal> TraerTodos()
        {
            var db = new BaseDataService<CategoriaFiscal>();
            var lista = db.Get();
            return lista;
        }

        public CategoriaFiscal TraerPorId(int id)
        {
            var db = new BaseDataService<CategoriaFiscal>();
            return db.GetById(id);
        }

        public void Eliminar(CategoriaFiscal categoriaFiscal)
        {
            var db = new BaseDataService<CategoriaFiscal>();
            db.Delete(categoriaFiscal);
        }

        public void Actualizar(CategoriaFiscal categoriaFiscal)
        {
            var db = new BaseDataService<CategoriaFiscal>();
            db.Update(categoriaFiscal);
        }
    }
}

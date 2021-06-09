using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizFactura
    {
        public void Agregar(Factura factura)
        {
            var db = new BaseDataService<Factura>();
            db.Create(factura);

        }

        public List<Factura> TraerTodos()
        {
            var db = new BaseDataService<Factura>();
            var lista = db.Get();
            return lista;
        }

        public Factura TraerPorId(int id)
        {
            var db = new BaseDataService<Factura>();
            return db.GetById(id);
        }

        public void Eliminar(Factura factura)
        {
            var db = new BaseDataService<Factura>();
            db.Delete(factura);
        }

        public void Actualizar(Factura factura)
        {
            var db = new BaseDataService<Factura>();
            db.Update(factura);
        }
    }
}

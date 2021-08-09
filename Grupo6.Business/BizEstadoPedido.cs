using Grupo6.Data.Services;
using Grupo6.Entities.Models;
using System.Collections.Generic;

namespace Grupo6.Business
{
    public class BizEstadoPedido
    {
        public void Agregar(EstadoPedido estado)
        {
            var db = new BaseDataService<EstadoPedido>();
            db.Create(estado);

        }

        public List<EstadoPedido> TraerTodos()
        {
            var db = new BaseDataService<EstadoPedido>();
            var lista = db.Get();
            return lista;
        }

        public EstadoPedido TraerPorId(int id)
        {
            var db = new BaseDataService<EstadoPedido>();
            return db.GetById(id);
        }

        public void Eliminar(EstadoPedido estado)
        {
            var db = new BaseDataService<EstadoPedido>();
            db.Delete(estado);
        }

        public void Actualizar(EstadoPedido estado)
        {
            var db = new BaseDataService<EstadoPedido>();
            db.Update(estado);
        }
    }
}

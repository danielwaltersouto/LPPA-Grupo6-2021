using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo6.Data.Services;
using Grupo6.Entities.Models;

namespace Grupo6.Business
{
    public class BizCatalogo
    {
        public List<CategoriaProducto> ListarCategoriasProd()
        {
            var db = new BaseDataService<CategoriaProducto>();
            var lista = db.Get();
            return lista;
        }

        public List<Producto> ListarProductos()
        {
            var db = new BaseDataService<Producto>();
            var lista = db.Get();
            return lista;
        }
    }
}

using Grupo6.Business;
using Grupo6.Entities.Models;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class CategoriaProductoController : Controller
    {
        // GET: CategoriaProducto
        public ActionResult Index()
        {
            var bizCategoriaProducto = new BizCategoriaProducto();
            var model = bizCategoriaProducto.TraerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var bizCategoriaProducto = new BizCategoriaProducto();
            var model = bizCategoriaProducto.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaProducto categoriaProducto) 
        {
            var bizCategoriaProducto = new BizCategoriaProducto();
            bizCategoriaProducto.Actualizar(categoriaProducto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete( int id) 
        {
            var bizCategoriaProducto = new BizCategoriaProducto();
            bizCategoriaProducto.Eliminar(id);

            return Json(new { status = "Success" });
        }
    }
}
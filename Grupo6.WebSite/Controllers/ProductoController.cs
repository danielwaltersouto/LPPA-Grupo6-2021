using Grupo6.Business;
using Grupo6.Entities.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            var bizCategoriaProducto = new BizCategoriaProducto();
            ViewBag.ListadoCategorias = new SelectList(bizCategoriaProducto.TraerTodos(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model, HttpPostedFileBase imagenProducto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var biz = new BizProducto();
                model.FotoProducto = new byte[imagenProducto.ContentLength];
                imagenProducto.InputStream.Read(model.FotoProducto, 0, imagenProducto.ContentLength);
                biz.Agregar(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                /// Que pasa con el error -> Bitacoras
                return View(model);
            }
        }
    }
}
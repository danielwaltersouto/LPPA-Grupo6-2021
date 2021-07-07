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

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var bizCategoriaProducto = new BizCategoriaProducto();
            var bizProducto = new BizProducto();
            ViewBag.ListadoCategorias = new SelectList(bizCategoriaProducto.TraerTodos(), "Id", "Nombre");
            var model = bizProducto.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto, HttpPostedFileBase imagenProducto)
        {
            var bizProducto = new BizProducto();

            if (imagenProducto == null)
            {
                producto.FotoProducto = bizProducto.TraerPorId(producto.Id).FotoProducto;
            }
            else 
            {
                producto.FotoProducto = new byte[imagenProducto.ContentLength];
                imagenProducto.InputStream.Read(producto.FotoProducto, 0, imagenProducto.ContentLength);
            }
            
            bizProducto.Actualizar(producto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bizProducto = new BizProducto();
            bizProducto.Eliminar(id);

            return Json(new { status = "Success" });
        }
    }
}
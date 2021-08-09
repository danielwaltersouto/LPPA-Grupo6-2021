using Grupo6.Business;
using Grupo6.Entities.Models;
using System;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class CategoriaFiscalController : Controller
    {
        // GET: CategoriaFiscal
        public ActionResult Index()
        {
            var bizCategoriaFiscal = new BizCategoriaFiscal();
            var model = bizCategoriaFiscal.TraerTodos();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaFiscal model)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var biz = new BizCategoriaFiscal();
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
            var bizCategoriaFiscal = new BizCategoriaFiscal();
            var model = bizCategoriaFiscal.TraerPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaFiscal categoriaFiscal)
        {
            var bizCategoriaFiscal = new BizCategoriaFiscal();
            bizCategoriaFiscal.Actualizar(categoriaFiscal);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bizCategoriaFiscal = new BizCategoriaFiscal();
            bizCategoriaFiscal.Eliminar(id);

            return Json(new { status = "Success" });
        }
    }
}
using Grupo6.Business;
using Grupo6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class CatalogoProductosController : Controller
    {
        // GET: CatalogoProductos        
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            var model = bizProducto.TraerTodos();
            return View(model);
        }

        // GET: CatalogoProductos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogoProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogoProductos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoProductos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoProductos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoProductos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoProductos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

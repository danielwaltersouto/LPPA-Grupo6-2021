using Grupo6.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            var bizFactura = new BizFactura();
            var model = bizFactura.TraerTodos();
            return View(model);
        }
    }
}
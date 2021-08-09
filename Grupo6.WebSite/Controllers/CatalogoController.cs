using Grupo6.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            var bizCatalogo = new BizCatalogo();
            var model = bizCatalogo.ListarProductos();
            return View(model);
        }
    }
}

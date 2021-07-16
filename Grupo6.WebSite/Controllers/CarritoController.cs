using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult MyCart()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddItemCart()
        {
            return View();
        }
    }
}
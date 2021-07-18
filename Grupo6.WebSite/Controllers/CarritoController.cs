using Grupo6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
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
            var items = new List<ItemCarrito>();
            var item = new ItemCarrito();
            item.ProductoId = 1;
            item.Cantidad = 1;
            items.Add(item);

            var pruebaXML = Services.Serializer.ObjectToXml(items);

            var lista = Services.Serializer.XmlToObject(pruebaXML);


            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddItemCart(int idProducto)
        {
            if (HttpRuntime.Cache.Get("Carrito") != null)
            {
                var prueba = HttpRuntime.Cache.Get("Carrito");
                HttpRuntime.Cache.Insert("Carrito", idProducto.ToString(), null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
            }
            HttpRuntime.Cache.Insert("Carrito", idProducto.ToString(), null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
            return RedirectToAction("MyCart");
        }
    }
}
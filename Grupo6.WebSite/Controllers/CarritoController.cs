using Grupo6.Business;
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
            if (HttpRuntime.Cache.Get("Carrito") != null)
            {

            }
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
        public ActionResult AddItemCart(int idProducto, int cantidad = 1)
        {
            if (HttpRuntime.Cache.Get("Carrito") != null)

            {
                var xml = (string)HttpRuntime.Cache.Get("Carrito");
                var items = Services.Serializer.XmlToObject(xml);

                var itemExistente = items.Exists(p => p.ProductoId == idProducto);

                if (itemExistente)
                {
                    items.Where(p => p.ProductoId == idProducto).ToList().ForEach(p => p.Cantidad = cantidad);
                }
                else
                {
                    var nuevoItem = new ItemCarrito();
                    var bizProducto = new BizProducto();
                    var producto = bizProducto.TraerPorId(idProducto);

                    nuevoItem.Cantidad = cantidad;
                    nuevoItem.Producto = producto;
                    nuevoItem.ProductoId = producto.Id;
                    items.Add(nuevoItem);
                }
                var itemsXml = Services.Serializer.ObjectToXml(items);
                HttpRuntime.Cache.Insert("Carrito", itemsXml, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
            }
            else
            {
                var nuevoItem = new ItemCarrito();
                var items = new List<ItemCarrito>();
                var bizProducto = new BizProducto();
                var producto = bizProducto.TraerPorId(idProducto);

                nuevoItem.Cantidad = cantidad;
                nuevoItem.Producto = producto;
                nuevoItem.ProductoId = producto.Id;
                items.Add(nuevoItem);

                var itemsXml = Services.Serializer.ObjectToXml(items);

                HttpRuntime.Cache.Insert("Carrito", itemsXml, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
            }
            return RedirectToAction("MyCart");
        }
    }
}
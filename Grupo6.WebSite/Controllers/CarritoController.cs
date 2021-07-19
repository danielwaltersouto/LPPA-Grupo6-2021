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
            var model = new List<ItemCarrito>();

            if (HttpRuntime.Cache.Get("Carrito") != null)
            {
                //var xml = (string)HttpRuntime.Cache.Get("Carrito");
                var items = GetItemsFromCache();
                var bizProducto = new BizProducto();
                decimal total = 0;

                foreach (var item in items)
                {
                    item.Producto = bizProducto.TraerPorId(item.ProductoId);
                    total += item.Cantidad * item.Producto.Precio;
                }
                ViewBag.PrecioTotal = total;
                model = items;
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ItemCart(int idProducto, int cantidad = 1)
        {
            if (HttpRuntime.Cache.Get("Carrito") != null)

            {
                //var xml = (string)HttpRuntime.Cache.Get("Carrito");
                var items = GetItemsFromCache();

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
                InsertItemsIntoCache(items);
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
                InsertItemsIntoCache(items);
            }
            return RedirectToAction("MyCart");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult DeleteItemCart(int idProducto)
        {

            //var xml = (string)HttpRuntime.Cache.Get("Carrito");
            var items = GetItemsFromCache();
            var itemToRemove = items.Single(i => i.ProductoId == idProducto);

            items.Remove(itemToRemove);
            InsertItemsIntoCache(items);

            return RedirectToAction("MyCart");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CheckOut()
        {
            if (HttpRuntime.Cache.Get("Carrito") != null)
            {
                var bizUsuario = new BizUsuario();
                var bizCarrito = new BizCarrito();
                var carrito = new Carrito();

                var items = GetItemsFromCache();
                var usuario = bizUsuario.TraerPorEmail("misme.ricardo@gmail.com");
                carrito.UsuarioId = usuario.Id;

                var nuevoCarrito = bizCarrito.Agregar(carrito);

                foreach (var item in items)
                {
                    item.CarritoId = nuevoCarrito.Id;
                    bizCarrito.AgregarItemCarrito(item);
                }
                InsertItemsIntoCache(items);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("MyCart");
            }

        }

        private void InsertItemsIntoCache(List<ItemCarrito> items)
        {
            var itemsXml = Services.Serializer.ObjectToXml(items);
            HttpRuntime.Cache.Insert("Carrito", itemsXml, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
        }

        private List<ItemCarrito> GetItemsFromCache()
        {
            var xml = (string)HttpRuntime.Cache.Get("Carrito");
            return Services.Serializer.XmlToObject(xml);
        }
    }
}
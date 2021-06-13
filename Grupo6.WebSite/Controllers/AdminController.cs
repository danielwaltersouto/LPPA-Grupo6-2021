using Grupo6.Business;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var bizProducto = new BizProducto();
            ViewBag.CantProductos = bizProducto.TraerTodos().Count;

            var bizUsuario = new BizUsuario();
            ViewBag.CantUsuarios = bizUsuario.TraerTodos().Count;

            var bizCategoriaProducto = new BizCategoriaProducto();
            ViewBag.CantCategoriasProducto = bizCategoriaProducto.TraerTodos().Count;

            var bizFacturas = new BizFactura();
            ViewBag.CantFacturas = bizFacturas.TraerTodos().Count;

            return View();
        }
    }
}
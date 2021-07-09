using Grupo6.Business;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            var bizCarrito = new BizCarrito();
            var model = bizCarrito.TraerTodos();
            return View(model);
        }
    }
}
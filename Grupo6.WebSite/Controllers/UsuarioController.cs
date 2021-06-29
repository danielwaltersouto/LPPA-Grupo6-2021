using Grupo6.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var bizUsuario = new BizUsuario();
            var model = bizUsuario.TraerTodos();
            return View(model);
        }
    }
}
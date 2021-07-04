using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Grupo6.Entities.Models;

namespace Grupo6.WebSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
       
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();

        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserRegister()
        {
           

              return View();

        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserRegister( Usuario Model , string pass1)
        {



            return View();

        }






    }
}
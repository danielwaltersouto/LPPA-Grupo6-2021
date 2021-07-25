using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo6.WebSite.Controllers
{
    public class FindLogController : Controller
    {
        // GET: FindLog
        [AllowAnonymous]
        public ActionResult Find()
        {
      
            
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Found(string Date)
        {


            return View();
        }







    }
}
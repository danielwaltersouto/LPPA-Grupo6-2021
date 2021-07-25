using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupo6.Services;


namespace Grupo6.WebSite.Controllers
{
    public class FindLogController : Controller
    {
        // GET: FindLog
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Find()
        {
      
            
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Find(Logger model)
        {

            List<Logger> loggers = new List<Logger>();
            loggers = Logger.ReadLog(model.Date);


            return View();

            // return RedirectToAction ("Found", "FindLog", new { list=loggers });




        }


        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Found(List<Logger> loggers)
        //{


        //  return View(loggers);
        //}

        [AllowAnonymous]
      
        public ActionResult Found(List<Logger> loggers)
        {


          return View();
            }






    }
}
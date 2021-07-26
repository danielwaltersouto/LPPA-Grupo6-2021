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
        public ActionResult Find( Logger model)
        {

           
            return RedirectToAction ("Found", "FindLog", new {id=model.Date});




        }
      
        

        [AllowAnonymous]
       
        
        public ActionResult Found(string id )
        {
            Logger loger = new Logger();
            loger.Date = id;
            List<Logger> loggers = new List<Logger>();
            loggers = Logger.ReadLog(loger.Date);


            return View(loggers);
            }






    }
}
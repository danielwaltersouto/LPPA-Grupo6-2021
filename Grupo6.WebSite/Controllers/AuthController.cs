using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupo6.Entities.Models;
using Grupo6.Services;


namespace Grupo6.WebSite.Controllers
{
    public class AuthController : Controller
    {
       [AllowAnonymous]
       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index( Usuario Model)

            
        {
            try
            {
                if (!ModelState.IsValid)

                { return View(); 
                }


                else 
                {


                    bool valida = ValidarIngreso.Validar(Model);

                    if (valida == true){ 
                     return RedirectToAction("Index", "Home");
                   
                    }


                    return View();
                 }
            
            }
            
       
           

             catch (Exception)
            {

                throw;
            }
        }
        



        [AllowAnonymous]
        [HttpGet]
        public ActionResult StartRecovery()


        {
        return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult StartRecovery(Usuario model)


        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }






    }
}
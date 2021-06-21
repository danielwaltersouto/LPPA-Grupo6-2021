using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
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

                {

                  
                    return View();
                    
                }


                else
                {


                    bool valida = ValidarIngreso.Validar(Model);

                    if (valida == true)
                    {

                        var claims = new[]
                 {
                    
                    new Claim(ClaimTypes.Email, Model.Email),
                    new Claim(ClaimTypes.Country, "Argentina"),
                };
                        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                        IOwinContext ctx = Request.GetOwinContext();
                        IAuthenticationManager authManager = ctx.Authentication;
                        authManager.SignIn(identity);





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


        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }



    }
}
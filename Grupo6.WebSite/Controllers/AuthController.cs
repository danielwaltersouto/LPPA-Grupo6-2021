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
using Grupo6.WebSite.ViewModels;
using Grupo6.Business;


namespace Grupo6.WebSite.Controllers
{
    public class AuthController : Controller
    {
       [AllowAnonymous]
       [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn( ViewModelLogIn  Model)

            
        {
            try
            {
                if (!ModelState.IsValid)

                {

                  
                    return View();
                    
                }


                else
                {
                    Usuario UserModel = new Usuario();
                    UserModel.Email = Model.Email;
                    UserModel.Password = Model.Password;
                    UserModel.UserToken = Model.Password;
                     
                    bool valida = ValidarIngreso.Validar(UserModel);

                    if (valida == true)
                    {

                        var claims = new[]
                 {
                    
                    new Claim(ClaimTypes.Email, Model.Email),
                    new Claim(ClaimTypes.Name, Model.Email),
                    
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
        public ActionResult StartRecovery(ViewModelRecovery model)

        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            BizUsuario Busuario = new BizUsuario();
            var oUsuario = Busuario.TraerPorEmail(model.Email);

            if (oUsuario != null)
            {
                string clave = Encriptador.GeneradorClave();



                CorreoElectronico.RecuperarPassword(oUsuario.NombreWeb, clave, oUsuario.Email);


                return RedirectToAction("Index", "Home");
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
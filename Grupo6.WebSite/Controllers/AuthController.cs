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
        public ActionResult LogIn(ViewModelLogIn Model)
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
                    var rol = string.Empty;

                    bool valida = ValidarIngreso.Validar(UserModel, ref rol);

                    if (valida == true)
                    {
                        var claims = new[] { new Claim(ClaimTypes.Email, Model.Email), new Claim(ClaimTypes.Name, Model.Email), new Claim(ClaimTypes.Role, rol) };
                        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                        IOwinContext ctx = Request.GetOwinContext();
                        IAuthenticationManager authManager = ctx.Authentication;

                        authManager.SignIn(identity);
                        Logger.WriteLog(State.Info, this.RouteData.Values["action"], identity.Name);
                        if (HttpRuntime.Cache.Get("Carrito") != null)
                        {
                            return RedirectToAction("MyCart", "Carrito");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(State.Critical, this.RouteData.Values["action"], ex.Message);
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePass()


        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePass(ViewModelChangePass viewModelChangePass)


        {

            try
            {
                if (!ModelState.IsValid)

                {
                    return View();

                }

                else

                {
                    string dato = viewModelChangePass.Password;
                    string email = User.Identity.Name;

                    BizUsuario bizUsuario = new BizUsuario();

                    bizUsuario.ActualizarPorEmail(dato, email);


                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)

            {
                Logger.WriteLog(State.BizChange, this.RouteData.Values["action"], ex.Message);
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


            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                BizUsuario Busuario = new BizUsuario();


                Usuario AutUsuario = Busuario.TraerPorEmail(model.Email);

                if (AutUsuario != null)
                {
                    string clave = Encriptador.GeneradorClave();
                  

                    Busuario.RecuperarPorEmail(clave,model.Email);

                    Logger.WriteLog(State.BizChange, this.RouteData.Values["action"], AutUsuario.Email);
                    return RedirectToAction("Index", "Home");
                }

                return View();


            }



            catch (Exception ex)
            {
                Logger.WriteLog(State.BizChange, this.RouteData.Values["action"], ex.ToString());
                throw;
            }

        }





        public ActionResult LogOut()
        {

            try
            {

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignOut("ApplicationCookie");
                Logger.WriteLog(State.Info, this.RouteData.Values["action"], User.Identity.Name);
                return RedirectToAction("Index", "Home");

            }

            catch (Exception ex)
            {
                Logger.WriteLog(State.BizChange, this.RouteData.Values["action"], ex.ToString());
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Grupo6.Entities.Models;
using Grupo6.Business;

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
        public ActionResult UserRegister(Usuario Model)
        {

            {
                try
                {
                    if (!ModelState.IsValid)

                    {
                        return View();

                    }

                     
                    else
                    {
                        var bizUsuario = new BizUsuario();

                      var oUser= bizUsuario.TraerPorEmail(Model.Email);
                        if (oUser.Email == Model.Email)
                        {
                            ViewBag.Mensaje = "eMail Ya Registrado! ";
                           
                            return View();
                        }
                        else { 


                        bizUsuario.Agregar(Model);

                        return RedirectToAction("Index", "Home");

                             }
                    }

                }

                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}  


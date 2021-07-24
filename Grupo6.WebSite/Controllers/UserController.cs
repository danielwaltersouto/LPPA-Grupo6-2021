using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Grupo6.Entities.Models;
using Grupo6.Business;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Grupo6.Services;

namespace Grupo6.WebSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [Authorize]

        public ActionResult UserProfile()
        {
            BizUsuario bizUsuario = new BizUsuario();
            Usuario usuario = new Usuario();
            var CUser = (ClaimsIdentity)User.Identity;
            var VMail = CUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            string eMail = VMail.Value;
            usuario = bizUsuario.TraerPorEmail(eMail);

            ViewBag.Usuario = usuario;


            return View();

        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserRegister()
        {

            return View();
        }


        //[Authorize]
        [HttpGet]
        public ActionResult UserRegisterAddress()
        {





            return View();
        }

        //[Authorize]
        [HttpPost]
        public ActionResult UserRegisterAddress(Direccion Model)
        {


            BizDireccion bizDireccion = new BizDireccion();
            BizUsuario bizUsuario = new BizUsuario();
            Usuario usuario = bizUsuario.TraerPorEmail(User.Identity.Name);
            Model.UsuarioId = usuario.Id;

            bizDireccion.Agregar(Model);



            return View("Index", "Home");
        }




        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserRegister(Usuario Model)
        {
            /* var bizUsuario = new BizUsuario();
            bizUsuario.Agregar(Model);
            return RedirectToAction("Index", "Home");*/

            try
            {
                if (!ModelState.IsValid)

                {
                    return View();
                }
                else
                {
                    var bizUsuario = new BizUsuario();
                    var oUser = new Entities.Models.Usuario();
                    oUser = bizUsuario.TraerPorEmail(Model.Email);
                    if (oUser != null)
                    {
                        ViewBag.Mensaje = "eMail Ya Registrado! ";

                        return View();
                    }
                    else
                    {

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

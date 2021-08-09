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

//modelo de logger*******
//Logger.WriteLog(State.Critical, this.RouteData.Values["action"], ex.Message);

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

            List<Direccion> Ldireccion = new List<Direccion>();

            BizDireccion bizDireccion = new BizDireccion();

            Ldireccion = bizDireccion.TraerTodos_id(usuario.Id);



            ViewBag.direccion_completa1 = Ldireccion[0].DireccionCompleta;
            ViewBag.direccion_completa1 = ViewBag.direccion_completa1 + "  " + Ldireccion[0].Localidad;

            if (Ldireccion.Count >= 2)
            {
                ViewBag.direccion_completa2 = Ldireccion[1].DireccionCompleta;
                ViewBag.direccion_completa2 = ViewBag.direccion_completa2 + "  " + Ldireccion[1].Localidad;
            }



            BizCategoriaFiscal bizCategoriaFiscal = new BizCategoriaFiscal();
            List<CategoriaFiscal> Lcategoria = new List<CategoriaFiscal>();

            CategoriaFiscal categoriaFiscal = new CategoriaFiscal();

            Lcategoria = bizCategoriaFiscal.Traer_detalle(usuario.CategoriaFiscalId);

            ViewBag.Fiscal = Lcategoria[0].Detalle;





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



            return RedirectToAction("Index", "Home");
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



        [HttpGet]
        public ActionResult UserEditProfile()
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

        [Authorize]
        [HttpPost]
        public ActionResult UserEditProfile(Usuario usuario)
        {

            BizUsuario bizUsuario = new BizUsuario();
            bizUsuario.Actualizar_profile(usuario);



         

            
        return RedirectToAction("UserProfile", "User");
        }

    }
}
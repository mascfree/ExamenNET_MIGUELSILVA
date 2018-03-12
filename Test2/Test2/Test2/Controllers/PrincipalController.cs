using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            Session["SessionUsuario"] = null;
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Index(string clave, string tipoUsuario)
        {
            Usuario usuario = null;
            using (var cliente = new HttpClient())
            {

                cliente.BaseAddress = new Uri("http://localhost:53660/api/");
                var postTask = cliente.GetAsync("Usuario/getAutentica/" + clave + "," + tipoUsuario);
                postTask.Wait();


                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Usuario>();
                    readTask.Wait();
                    usuario = readTask.Result;
                    if (usuario.TipoUsuario == null) {
                        usuario = new Usuario();
                        usuario.Clave = clave;
                        usuario.TipoUsuario = tipoUsuario;
                        ModelState.AddModelError(string.Empty, "Error de Autenticación");
                        Session["SessionUsuario"] = null;
                    } else {
                        Session["SessionUsuario"] = usuario;
                        return RedirectToAction("Index","Home");
                    }
                    

                }
                else
                {
                    usuario = new Usuario();
                    ModelState.AddModelError(string.Empty, "Error en el Servidor");
                    return RedirectToAction("Index");
                }

            }

            return View(usuario);
        }

    }
}
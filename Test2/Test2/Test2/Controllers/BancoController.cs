using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Test2.Models;
using System.Linq;

namespace Test2.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            IEnumerable<Banco> bancos = null;

            using (var cliente = new HttpClient()) {

                cliente.BaseAddress = new Uri("http://localhost:53660/api/");

                var responseTask = cliente.GetAsync("Banco");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {
                    var readTask = result.Content.ReadAsAsync<IList<Banco>>();
                    readTask.Wait();
                    bancos = readTask.Result;
                }else
                {

                    bancos = Enumerable.Empty<Banco>();
                    ModelState.AddModelError(string.Empty, "Error de Servidor");
                }

            }

                return View(bancos);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Banco banco) {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:53660/api/banco");

                //HTTP POST
                var postTask = cliente.PostAsJsonAsync<Banco>("banco", banco);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            ModelState.AddModelError(string.Empty, "Error de Servidor");
            return View(banco);

        }
    }
}
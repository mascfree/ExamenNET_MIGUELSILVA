using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class WS1Controller : Controller
    {
        // GET: WS1
        public ActionResult Index()
        {
            IEnumerable<OrdenPago> lista = null;
            using (var cliente = new HttpClient())
            {

                cliente.BaseAddress = new Uri("http://localhost:53660/api/");
                var postTask = cliente.GetAsync("OrdenPago/getOrdenPago/3,1,S");
                postTask.Wait();


                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<OrdenPago>>();
                    readTask.Wait();
                    lista = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error en el Servidor");
                    return RedirectToAction("Index");
                }

            }
            return View(lista);
        }
    }
}
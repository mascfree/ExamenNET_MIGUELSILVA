using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class WS2Controller : Controller
    {
        // GET: WS2
        public ActionResult Index()
        {
            IEnumerable<Sucursal> lista = null;
            using (var cliente = new HttpClient())
            {

                cliente.BaseAddress = new Uri("http://localhost:53660/api/");
                var postTask = cliente.GetAsync("Sucursal/getSucursalesxBanco/2");
                postTask.Wait();


                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Sucursal>>();
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
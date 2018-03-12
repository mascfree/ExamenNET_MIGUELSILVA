using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Test2.Models;
using System.Net.Http.Headers;

namespace Test2.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            IEnumerable<Sucursal> sucursales = null;

            using (var cliente = new HttpClient())
            {

                cliente.BaseAddress = new Uri("http://localhost:53660/api/");

                var responseTask = cliente.GetAsync("Sucursal");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Sucursal>>();
                    readTask.Wait();
                    sucursales = readTask.Result;
                }
                else
                {

                    sucursales = Enumerable.Empty<Sucursal>();
                    ModelState.AddModelError(string.Empty, "Error de Servidor");
                }

            }

            return View(sucursales);
        }

        public ActionResult create()
        {
            Sucursal sucursal = new Sucursal();
            sucursal.Bancos = GetAllBancos(); 
            return View(sucursal);
        }

        [HttpPost]
        public ActionResult create(Sucursal sucursal)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:53660/api/sucursal");
                sucursal.Bancos = GetAllBancos();
                //HTTP POST
                var postTask = cliente.PostAsJsonAsync<Sucursal>("sucursal", sucursal);
                postTask.Wait();
                

                var result = postTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            ModelState.AddModelError(string.Empty, "Error de Servidor");
            return View(sucursal);

        }

        public List<Banco> GetAllBancos()
        {
            var lista = new List<Banco>();

            var httpCliente = new HttpClient();
            httpCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = httpCliente.GetAsync("http://localhost:53660/api/banco/").Result;
            response.EnsureSuccessStatusCode();
            List<Banco> bancoList = response.Content.ReadAsAsync<List<Banco>>().Result;
            if (!object.Equals(bancoList, null))
            {
                var bancos = bancoList.ToList();
                return bancos;
            }
            else
            {
                return null;
            }
        }

    }
}
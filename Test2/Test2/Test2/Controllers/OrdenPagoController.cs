using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class OrdenPagoController : Controller
    {
        // GET: OrdenPago
        public ActionResult Index()
        {
            IEnumerable<OrdenPago> ordenesPago = null;

            using (var cliente = new HttpClient())
            {

                cliente.BaseAddress = new Uri("http://localhost:53660/api/");

                var responseTask = cliente.GetAsync("OrdenPago");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<OrdenPago>>();
                    readTask.Wait();
                    ordenesPago = readTask.Result;
                }
                else
                {

                    ordenesPago = Enumerable.Empty<OrdenPago>();
                    ModelState.AddModelError(string.Empty, "Error de Servidor");
                }

            }

            return View(ordenesPago);
        }

        //public ActionResult create()
        //{
            
        //    OrdenPago ordenPago= new OrdenPago();
        //    ordenPago.Bancos = GetAllBancos();
        //    ordenPago.Sucursales = GetSucursalxBanco(ordenPago.CodBanco);
        //    return View(ordenPago);
        //}


        public ActionResult create( int CodBanco=0,int CodSucursal=0)
        {
            OrdenPago ordenPago = new OrdenPago();
            ordenPago.Bancos = GetAllBancos();
            ordenPago.CodBanco = CodBanco;
            ordenPago.Sucursales = GetSucursalxBanco(CodBanco);
            ordenPago.CodSucursal = CodSucursal;
            return View(ordenPago);
        }

        [HttpPost]
        public ActionResult create(OrdenPago ordenPago,string Guardar)
        {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("http://localhost:53660/api/OrdenPago");
                    //if (ordenPago.CodSucursal==0 || ordenPago.CodBanco==0)
                    if(Guardar==null)
                    return RedirectToAction("create", new { CodBanco = ordenPago.CodBanco,CodSucursal =ordenPago.CodSucursal });
                    
                    //HTTP POST
                    var postTask = cliente.PostAsJsonAsync<OrdenPago>("OrdenPago", ordenPago);
                    postTask.Wait();


                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }


                }
            ModelState.AddModelError(string.Empty, "Error de Servidor");

            return View(ordenPago);

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

        public List<Sucursal> GetSucursalxBanco(int id)
        {
            var lista = new List<Sucursal>();

            var httpCliente = new HttpClient();
            httpCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = httpCliente.GetAsync("http://localhost:53660/api/sucursal/getSucursalesxBanco/" + id).Result;
            response.EnsureSuccessStatusCode();
            List<Sucursal> sucursalList = response.Content.ReadAsAsync<List<Sucursal>>().Result;
            if (!object.Equals(sucursalList, null))
            {
                var sucursal = sucursalList.ToList();
                return sucursal;
            }
            else
            {
                return null;
            }
        }



    }
}
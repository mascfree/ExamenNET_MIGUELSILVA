using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test2.Models;

namespace Test2.Controllers.api
{
    public class BancoController : ApiController
    {

        
        static List<Banco> lista = new List<Banco>() {
            new Banco { CodBanco = 1, Nombre = "BCP",Direccion="LIMA",FechaRegistro=DateTime.Now },
            new Banco { CodBanco = 2, Nombre = "BBVA",Direccion="LIMA",FechaRegistro=DateTime.Now },
            new Banco { CodBanco = 3, Nombre = "INTERBANK",Direccion="LIMA",FechaRegistro=DateTime.Now },
            new Banco { CodBanco = 4, Nombre = "RIPLEY",Direccion="LIMA",FechaRegistro=DateTime.Now },
        };

       
        //public List<Banco> GetAllBanco()
        //{
        //    return lista;
        //}

        public Banco getBanco(int id)
        {
            var banco = lista.FirstOrDefault((p) => p.CodBanco == id);
            return banco;
        }

        public IHttpActionResult PostNuevoBanco(Banco banco)
        {
            if (!ModelState.IsValid)
                return BadRequest("No es un modelo Válido");

            lista.Add(new Banco { CodBanco = banco.CodBanco, Nombre = banco.Nombre, Direccion = banco.Direccion });
            return Ok();
        }

        [HttpGet, ActionName("GetAllBancos")]
        public HttpResponseMessage GetAllBancos()
        {
            HttpResponseMessage response;
            try
            {
                var detailsResponse = lista;
                if (detailsResponse != null)
                    response = Request.CreateResponse<List<Banco>>(HttpStatusCode.OK, detailsResponse);
                else

                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
            return response;
        }




    }
}

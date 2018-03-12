using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test2.Models;
using System.Linq;

namespace Test2.Controllers.api
{
    public class SucursalController : ApiController
    {

        static List<Sucursal> lista = new List<Sucursal>() {
            new Sucursal { CodBanco = 1,CodSucursal=1, Nombre = "AGENCIA LIMA",Direccion="LIMA",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 1,CodSucursal=2, Nombre = "AGENCIA TRUJILLO",Direccion="TRUJILLO",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 1,CodSucursal=3, Nombre = "AGENCIA LAMBAYEUE",Direccion="LAMBAYEQUE",FechaRegistro=DateTime.Now },

            new Sucursal { CodBanco = 2,CodSucursal=1, Nombre = "AGENCIA PIURA",Direccion="PIURA",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 2,CodSucursal=2, Nombre = "AGENCIA HUANCAYO",Direccion="HUANCAYO",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 2,CodSucursal=3, Nombre = "AGENCIA MOQUEGUA",Direccion="MOQUEGUA",FechaRegistro=DateTime.Now },

            new Sucursal { CodBanco = 3,CodSucursal=1, Nombre = "AGENCIA TACNA",Direccion="TACNA",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 3,CodSucursal=2, Nombre = "AGENCIA PUNO",Direccion="PUNO",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 3,CodSucursal=3, Nombre = "AGENCIA LURIGANCHO",Direccion="LIMA",FechaRegistro=DateTime.Now },

            new Sucursal { CodBanco = 4,CodSucursal=1, Nombre = "AGENCIA ATE",Direccion="LIMA",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 4,CodSucursal=2, Nombre = "AGENCIA SAN MIGUEL",Direccion="LIMA",FechaRegistro=DateTime.Now },
            new Sucursal { CodBanco = 4,CodSucursal=3, Nombre = "AGENCIA IQUITOS",Direccion="IQUITOS",FechaRegistro=DateTime.Now },

        };


        //public List<Sucursal> GetAllSucursal()
        //{
        //    return lista;
        //}

        [ActionName("getSucursalesxBanco")]
        public List<Sucursal> getSucursalesxBanco(int id)
        {

            var ls = from s in lista where s.CodBanco == id select s;         
            return ls.ToList<Sucursal>();
        }

        public IHttpActionResult PostNuevaSucursal(Sucursal sucursal)
        {
            if (!ModelState.IsValid)
                return BadRequest("No es un modelo Válido");

            lista.Add(new Sucursal { CodBanco = sucursal.CodBanco,CodSucursal = sucursal.CodSucursal, Nombre = sucursal.Nombre, Direccion = sucursal.Direccion, FechaRegistro = sucursal.FechaRegistro });
            return Ok();
        }

        [HttpGet, ActionName("GetAllSucursales")]
        public HttpResponseMessage GetAllSucursales()
        {
            HttpResponseMessage response;
            try
            {
                var detailsResponse = lista;
                if (detailsResponse != null)
                    response = Request.CreateResponse<List<Sucursal>>(HttpStatusCode.OK, detailsResponse);
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

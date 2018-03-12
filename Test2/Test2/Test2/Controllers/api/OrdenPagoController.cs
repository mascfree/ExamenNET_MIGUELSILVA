using System;
using System.Collections.Generic;
using System.Web.Http;
using Test2.Models;
using System.Linq;

namespace Test2.Controllers.api
{
    public class OrdenPagoController : ApiController
    {
        static List<OrdenPago> lista = new List<OrdenPago> {
            new OrdenPago { CodBanco=1, CodSucursal=1, Monto =35.5M, Moneda= "S", Estado = "P", FechaRegistro = DateTime.Now},
            new OrdenPago { CodBanco=2, CodSucursal=2, Monto =24.2M, Moneda= "S", Estado = "P", FechaRegistro = DateTime.Now},
            new OrdenPago { CodBanco=3, CodSucursal=1, Monto =244.2M, Moneda= "S", Estado = "D", FechaRegistro = DateTime.Now},
            new OrdenPago { CodBanco=3, CodSucursal=1, Monto =1245.78M, Moneda= "S", Estado = "P", FechaRegistro = DateTime.Now},
            new OrdenPago { CodBanco=3, CodSucursal=1, Monto =1234.56M, Moneda= "S", Estado = "F", FechaRegistro = DateTime.Now},
            new OrdenPago { CodBanco=3, CodSucursal=1, Monto =345.65M, Moneda= "S", Estado = "A", FechaRegistro = DateTime.Now},
            new OrdenPago { CodBanco=3, CodSucursal=1, Monto =1000M, Moneda= "D", Estado = "A", FechaRegistro = DateTime.Now}
        };

        public List<OrdenPago> GetAllOrdenPago()
        {
            return lista;
        }

        public IHttpActionResult PostNuevaOrdenPago(OrdenPago ordenPago)
        {
            if (!ModelState.IsValid)
                return BadRequest("No es un modelo Válido");

            lista.Add(new OrdenPago { CodBanco = ordenPago.CodBanco, CodSucursal = ordenPago.CodSucursal, Moneda = ordenPago.Moneda, Monto= ordenPago.Monto, Estado = ordenPago.Estado,FechaRegistro = ordenPago.FechaRegistro });
            return Ok();
        }


        [ActionName("GetOrdenPago")]
        public List<OrdenPago> GetOrdenPago(int codBanco,int codSucursal, string tipoMoneda)
        {

            var ls = from s in lista where s.CodBanco == codBanco && s.CodSucursal == codSucursal && s.Moneda.Equals(tipoMoneda) select s;
            return ls.ToList<OrdenPago>();
        }

    }
}

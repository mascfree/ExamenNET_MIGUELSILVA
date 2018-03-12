using System;
using System.Collections.Generic;
using System.Web.Http;
using Test2.Models;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace Test2.Controllers.api
{
    public class UsuarioController : ApiController
    {
        static List<Usuario> lista = new List<Usuario> {
            new Usuario { Codigo=1,Nombre="JUAN PEREZ",TipoUsuario="04",Clave="123",FechaRegistro=DateTime.Now},
            new Usuario { Codigo=6,Nombre="JUAN MARTINES",TipoUsuario="05",Clave="123",FechaRegistro=DateTime.Now},
            new Usuario { Codigo=9,Nombre="MIGUEL SILVA",TipoUsuario="06",Clave="123",FechaRegistro=DateTime.Now}
        };

        public List<Usuario> GetAllUsuario()
        {
            return lista;
        }


        public HttpResponseMessage getAutentica(string clave, string tipoUsuario)
        {


            Usuario usuario = new Usuario();
            var u = lista.FirstOrDefault((p) => p.Clave.Equals(clave) && p.TipoUsuario.Equals(tipoUsuario));
            if (u != null)
            {
                usuario = u;
            }
            HttpResponseMessage response;
            try
            {
                var detailsResponse = usuario;
                if (detailsResponse != null)
                    response = Request.CreateResponse<Usuario>(HttpStatusCode.OK, detailsResponse);
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

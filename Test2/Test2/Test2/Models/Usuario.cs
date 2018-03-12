using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class Usuario
    {

        public Usuario()
        {
            this.TiposUsuario = new List<ListaGenerica>();

            TiposUsuario.Add(new ListaGenerica { codigo = "04", descripcion = "OPERADOR1" });
            TiposUsuario.Add(new ListaGenerica { codigo = "05", descripcion = "OPERADOR2" });
            TiposUsuario.Add(new ListaGenerica { codigo = "06", descripcion = "ADMINISTRADOR" });
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string TipoUsuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; }

        public IList<ListaGenerica> TiposUsuario { get; set; }
    }
}
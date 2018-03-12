using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{

    public class Banco
    {
        public int CodBanco { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
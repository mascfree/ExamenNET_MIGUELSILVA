using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class OrdenPago
    {

        public OrdenPago()
        {
            this.Bancos = new List<Banco>();
            this.Sucursales = new List<Sucursal>();

            this.Monedas = new List<ListaGenerica>();
            this.Estados = new List<ListaGenerica>();

            Monedas.Add(new ListaGenerica { codigo = "S", descripcion = "SOLES" });
            Monedas.Add(new ListaGenerica { codigo = "D", descripcion = "DOLARES" });

            Estados.Add(new ListaGenerica { codigo = "P", descripcion = "PAGADA" });
            Estados.Add(new ListaGenerica { codigo = "D", descripcion = "DECLINADA" });
            Estados.Add(new ListaGenerica { codigo = "F", descripcion = "FALLIDA" });
            Estados.Add(new ListaGenerica { codigo = "A", descripcion = "ANULADA" });

        }

        public int CodBanco { get; set; }
        public int CodSucursal { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        public IList<Banco> Bancos { get; set; }
        public IList<Sucursal> Sucursales { get; set; }

        public IList<ListaGenerica> Monedas { get; set; }
        public IList<ListaGenerica> Estados { get; set; }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

   public class MoneyParts
    {
       /*
       - El metodo verifica que el monto sea mayor y divisible, entre los denominadores.
       - Si cumple la condición, se va almacenando en una misma lista de combinaciones posibles, para llegar al monto.
       */
       public ArrayList build(string monto){
           decimal m = Convert.ToDecimal(monto);
           decimal cn = 0;
           ArrayList c = new ArrayList();
           decimal[] d = { 0.05M, 0.1M, 0.2M, 0.5M, 1, 2, 5, 10, 20, 50, 100, 200 };
           for (int i = 0; i < d.Length; i++) {
               if (m >= d[i] &&  m % d[i] == 0)
               {  
                  cn =  m / d[i];
                  if (cn > 0)
                  {
                      c.Add("[");
                      for (int j = 0; j < cn; j++)
                      {
                          c.Add(d[i]);
                      }
                      c.Add("]");
                  }
               }
           }
           return c;
       }
    }

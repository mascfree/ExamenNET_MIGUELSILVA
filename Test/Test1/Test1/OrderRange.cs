using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

    public class OrderRange
    {
        /*
        - El metodo retorna dos listas ordenadas, en una los valores pares, y en la otra los demás números ingresados
        - Si se ingresan "," vacías, se asumen los valores como 0
        - Si se ingresa ".", se reemplaza por ","
        */
        public void build(String cadena, out ArrayList np, out ArrayList nr)
        {
            
            np = new ArrayList();
            nr = new ArrayList();

            cadena = cadena.Replace(".", ",");
            string[] c = cadena.Split(',');
            int[] n = new int[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                if (String.IsNullOrEmpty(c[i]))
                {
                    n[i] = 0; 
                }
                else
                {
                    n[i] = Convert.ToInt32(c[i]);
                }
            }

            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] % 2 == 0)
                {
                    np.Add(n[i]);
                }
                else
                {
                    nr.Add(n[i]);
                }
            }
            np.Sort();
            nr.Sort();
            

        }
    }


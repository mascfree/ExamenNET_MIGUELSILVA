using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



    public class ChangeString
    {
        /*
        - El Metodo busca cada caracter de la cadena ingresada, en el alfabeto, si la ubica obtiene la letra siguiente.
        - Busca tanto en mayuscula y minuscula
        - Si el caracter buscado es z, se asume que retona la letra a
        - Si no se ubica el caracter, se retorna el mismo valor
        */ 
        public String build(String cadena)
        {
            String l;
            int pos = -1;
            String alfabeto ="abcdefghijklmnñopqrstuvwxyzaABCDEFGHIJKLMNÑOPQRSTUVWXYZA";
            String result="";
            char[] c = cadena.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {   pos  = alfabeto.IndexOf(c[i]);
                if (pos >= 0)
                {
                    l = alfabeto.Substring(pos + 1,1);
                }
                else {
                    l = char.ToString(c[i]);
                }
                result += l;
            }
            
            return result;
        }

        
    }


   

    

    


using System;
using System.Collections;
using System.Linq;
using System.Text;


/*
 POSTULANTE. MIGUEL ANGEL SILVA CAJUSOL
 IDE VISUAL STUDIO 2015
 LENGUAJE C#
 */

/* Consola para testear métodos
 Consideraciones:
 - Para testear los ejercicios, sólo dejar descomentado las líneas que le corresponden, según cabecera indicada.
*/ 
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            // ------- Ejercicio 1 ----------------------------- CLASE ChangeString
            String output;
            String input;
            ChangeString cs = new ChangeString();
            Console.WriteLine("Ingrese Cadena:");
            input = Console.ReadLine();
            output = cs.build(input);
            Console.WriteLine("Salida:");
            Console.Write(output);
            Console.ReadKey();



            //--------- ejercicio 2 ----------------------------- CLASE OrderRange
            //ArrayList np;
            //ArrayList nr;
            //String input;
            //OrderRange or = new OrderRange();
            //Console.WriteLine("Ingrese Números enteros positivos, separados por comas ejm(1,2,3,4...):");
            //input = Console.ReadLine();
            //or.build(input, out np, out nr);
            //Console.WriteLine("Salida:");
            //Console.WriteLine("Colección de Pares:");
            //foreach (object n in np)
            //{
            //    Console.Write("{0},", n);
            //}
            //Console.WriteLine("\nColección de Resto:");
            //foreach (object n in nr)
            //{
            //    Console.Write("{0},", n);
            //}
            //Console.ReadKey();



            //--------- ejercicio 3 ----------------------------- CLASE MoneyParts
            //ArrayList output;
            //String input;
            //MoneyParts mp = new MoneyParts();
            //Console.WriteLine("Ingrese Monto, para obtener combinaciones:");
            //input = Console.ReadLine();
            //output = mp.build(input);
            //Console.WriteLine("\nSalida:");
            //foreach (object n in output)
            //{
            //    Console.Write("{0} ", n);
            //}
            //Console.ReadKey();



        }
    }
}



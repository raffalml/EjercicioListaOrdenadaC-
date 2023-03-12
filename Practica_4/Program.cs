using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Se crea la ListaDoble.*/
            ListaOrdenada ListaDoble = new ListaOrdenada();

            /*Se crea un string con el que se controlara el while
             que imprimira el MENU.*/
            string op = "A";
            /*while que se encarga del MENU.*/
            while (op != "G")
            {
                /*Se imprimen las opciones del MENU.*/
                Console.WriteLine("\n\tMENU\n\nElige el inciso que desees:\n");
                Console.Write("\tB -- Agregar los valores 7, 3, -4, 5, 6, 5, 9 e imprimir la lista.");
                Console.Write("\n\tC -- Quitar un elemento.\n\tD -- Imprimir los elementos en las posiciones 0, 2 y -1 y el ultimo elemento.");
                Console.Write("\n\tE -- Imprimir la longitud de la lista");
                Console.Write("\n\tF -- Agregar los elementos 2 y 4 e imprimir la lista.");
                Console.Write("\n\tG -- Salir.");
                Console.Write("\n\n\tLa Lista ya ha sido creada por defaut.\t");
                /*Se lee la opción del usuario.*/
                op = Console.ReadLine();
                /*Con switch, se controlan las opciones que 
                 puede elegir el usuario.*/
                switch (op)
                {
                    /*En este switch, yo de antemano cree la ListaDoble al principio,
                     empezando entonces con el inciso B.*/
                    case "B":
                        /*Se manda a llamar los métodos insertar e Imprimir,
                         para reflejar el funcionamiento de estos.*/
                        ListaDoble.insertar(7);
                        ListaDoble.insertar(3);
                        ListaDoble.insertar(-4);
                        ListaDoble.insertar(5);
                        ListaDoble.insertar(6);
                        ListaDoble.insertar(5);
                        ListaDoble.insertar(9);
                        ListaDoble.Imprimir();
                        /*Estas dos lineas, paran el funcionamiento del programa
                         y limpian la pantalla despues de presionar un enter.*/
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "C":
                        /*Se manda a llamar los métodos Quitar e Imprimir,
                         para reflejar el funcionamiento de estos.*/
                        ListaDoble.Quitar();
                        ListaDoble.Imprimir();
                        Console.ReadLine();
                        Console.Clear();
                        /*Estas dos lineas, paran el funcionamiento del programa
                         y limpian la pantalla despues de presionar un enter.*/
                        break;
                    case "D":
                        /*Se manda a llamar los métodos Leer e Imprimir,
                         para reflejar el funcionamiento de estos.
                         *Yo cree dos metodos mas para facilitar el proposito
                         del inciso D.
                         *El metodo Posición sirve para imprimir los resultados
                         con sus explicaciones.
                         *El metodo devolverUltimoValor sirve para regresar el 
                         valor del ultimo nodo de la Lista, esto porque se 
                         pide imprimir el indice del ultimo elemento.*/
                        ListaDoble.Imprimir();
                        Console.WriteLine("\n");
                        int num = ListaDoble.Leer(0);
                        ListaDoble.Posición(num, 0);
                        num = ListaDoble.Leer(2);
                        ListaDoble.Posición(num, 2);
                        num = ListaDoble.Leer(-1);
                        ListaDoble.Posición(num, -1);
                        num = ListaDoble.Leer(ListaDoble.devolverUltimoValor());
                        ListaDoble.Posición(num, ListaDoble.devolverUltimoValor());
                        /*Estas dos lineas, paran el funcionamiento del programa
                         y limpian la pantalla despues de presionar un enter.*/
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "E":
                        /*Se manda a llamar los métodos Longitud e Imprimir,
                         para reflejar el funcionamiento de estos.*/
                        ListaDoble.Imprimir();
                        Console.WriteLine("\n\n\tLa longitud es de : " + ListaDoble.Longitud());
                        /*Estas dos lineas, paran el funcionamiento del programa
                         y limpian la pantalla despues de presionar un enter.*/
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "F":
                        /*Se manda a llamar los métodos insertar e Imprimir,
                         para reflejar el funcionamiento de estos.*/
                        ListaDoble.insertar(2);
                        ListaDoble.insertar(4);
                        ListaDoble.Imprimir();
                        /*Estas dos lineas, paran el funcionamiento del programa
                         y limpian la pantalla despues de presionar un enter.*/
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "G":
                        /*Se despide el programa del usuario.*/
                        Console.WriteLine("\nBye bye, Adios!!");
                        break;
                    default:
                        Console.WriteLine("\n----ERROR----\tOpción no valida");
                        /*Estas dos lineas, paran el funcionamiento del programa
                         y limpian la pantalla despues de presionar un enter.*/
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            /*Para el programa hasta recibir un enter.*/
            Console.ReadLine();
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_4
{
    class ListaOrdenada
    {
        /*Se inicializan head y tail a NULL*/
        Nodo head = null;
        Nodo tail = null;

        //Metodo insertar: Iserta los nodos de la Lista.
        public void insertar(int valor) //Recibe el valor que se desea insertar.
        {
            /*Se crea una variable de tipo boolenao, la cual validara si algún
             numero esta repetido en la Lista.*/
            bool resp = false;
            /*El if valida si el número que se desea insertar no sea negativo
             y que no sea un valor repetido, por ello, las dos condiciones.*/
            if (valor >= 0 && resp == enBuscaDeUnRepetido(valor))
            {
                /*Se crea un objeto de la Clase Nodoy a la variable 
                 val de ese objeto, se le iguala al valor.*/
                Nodo nuevo = new Nodo();
                nuevo.val = valor;

                /*Este if sirve para ver si la lista esta vacia, de ser asi
                 tanto head como tail apuntan a NULL*/
                if (head == null)
                {
                    /*A este if se entrara solo cuando la lista no contenga
                     ningun elemento, se indican las diferentes ligas que se
                     deben hacer para que la lista tenga estructura doblemente
                     ligada.*/
                    nuevo.sig = tail;
                    nuevo.ant = tail;
                    head = nuevo;
                    tail = nuevo;
                }
                /*A este else se entra cuando haya almenos 1 elemento en la lista.*/
                else
                {
                    /*Este if valida que numero es mayor, si el que es apuntado por
                     head, o el numero que le pertenece al objeto nuevo, si el valor de
                     nuevo es menor, se insertara inmediatamente nuevo por el head, 
                     convirtiendose en el nuevo head.*/
                    if (head.val > nuevo.val)
                    {
                        /*Las asignaciones correspondientes para insertar nuevo a la
                         Lista.*/
                        nuevo.sig = head;
                        nuevo.ant = head.ant;
                        head.ant = nuevo;
                        head = nuevo;
                    }
                    /*A este else se entrara cuando el valor del nodo nuevo sea mayor al
                     numero que es apuntado por head. Lo cual significa que hay que recorrer
                     la lista para encontrar la posicion adecuada para insertarlo.*/
                    else
                    {
                        /*Se declara una variable auxiliar de tipo Nodo.*/
                        Nodo aux = head;
                        /*Este while sirve para hayar la posición adecuada para insertar
                         el nodo nuevo.
                         *Posee dos condiciones, la 1era sirve para detener al while, en caso de
                         que recorra toda la lista, la 2da tambien detiene al while, pero en el nodo
                         que contiene a un valor mayor al que se quiere ingresar.*/
                        while (aux != null && aux.val < nuevo.val)
                        {
                            /*Se recorre la variable aux de nodo a nodo.*/
                            aux = aux.sig;
                        }
                        /*Este if valida si se recorrio toda la lista, de serlo, aux valdria NULL, asi
                         que si no la recorrio toda, se inserta el nuevo nodo.*/
                        if (aux != null)
                        {
                            /*Las asignaciones correspondientes para estructurar el nuevo
                             nodo entre dos nodos de la Lista.*/
                            nuevo.sig = aux;
                            nuevo.ant = aux.ant;
                            aux.ant.sig = nuevo;
                            aux.ant = nuevo;
                        }
                        /*Entrar a este else, significa que se recorrio toda la lista, y ningun
                         nodo es mayor al que se va a insertar, por lo que ese nodo se insertara
                         en el tail.*/
                        else
                        {
                            /*Las asignaciones correspondientes para que se inserte el nuevo
                             nodo en el tail.*/
                            tail.sig = nuevo;
                            nuevo.ant = tail;
                            nuevo.sig = null;
                            tail = nuevo;
                        }
                    }
                }
            }
            /*A este else entra si el valor que se quiere insertar es negativo
             o es un numero ya contenido en la Lista.*/
            else
            {
                /*Este if tiene como proposito la distincion entre el tipo de error, 
                 o que el numero es negativo, o que es un numero repetido.*/
                if (valor < 0)
                {
                    Console.WriteLine("\n----ERROR----\t[" + valor.ToString() + "]\tNúmero negativo!!");
                }
                else
                {
                    Console.WriteLine("\n----ERROR----\t[" + valor.ToString() + "]\tNúmero repetido!!");
                }
            }
            
        }
        
        //Metodo enBuscaDeUnRepetido: Metodo que colabora con el metodo insertar
        //para saber si el valor insertado esta repetido.
        private bool enBuscaDeUnRepetido(int num) //Recibe el valor que se desea insertar.
        {
            /*Se crea un dato de tipo bool, y se le inicializa como si fuera
             falso que se repite el valor en la Lista.*/
            bool respuesta = false;
            /*Se declara una variable auxiliar de tipo Nodo y se le pasa la referencia de head.*/
            Nodo aux = head;
            /*Con este while, recorre la Lista en busca de un número repetido.*/
            while(aux != null)
            {
                /*Si encuentra un numero repetido, a respuesta la vuelve
                 true, indicando de que si hay un numero repetido.*/
                if (aux.val == num)
                    respuesta = true;
                /*Se recorre aux de nodo en nodo.*/
                aux = aux.sig;
            }
            /*Regresa la respuesta.*/
            return respuesta;
        }

        //Metodo Leer: Regresa el indice de la posición de un elemento.
        public int Leer(int i) //Recibe el elemento buscado.
        {
            /*Se declara una variable auxiliar.*/
            Nodo aux = head;
            /*Se inicializa un contador en 0.*/
            int j = 0;
            /*Con este while se recorre la lista, y se detiene cuando
             se haya encontrado el elemento buscado, o cuando se haya
             recorrido toda la Lista.*/
            while (aux.val != i && aux.sig != null)
            {
                /*Cada vez que entre al while, significara que el indice
                 en el que el elemento buscado se encuentra, va creciendo.*/
                j++;
                /*Se recorre aux nodo por nodo.*/
                aux = aux.sig;
            }
            /*Este if, valida si se encontro el elemento buscado, de no 
             serlo, regresa un -1, y si fue hayado, regresa j, que contendra
             el indice en el que se encuentra dicho valor.*/
            if (aux.sig == null && aux.val != i)
                return -1;
            else
                return j;
        }

        //Metodo Posicion: Esta función la cree para imprimir la posición que regresa el metodo
        //Leer, y asi simplificar un poco las lineas de código.
        public void Posición(int n, int val) //Recibe el indice regresado por el metodo Leer y el valor que se busco.
        {
            /*Si n es igual a -1, significa que no se encontro el valor buscado.*/
            if (n != -1)
                Console.WriteLine("\n\t[" + val.ToString() + "] Se encuentra en el indice: " + n.ToString());
            else
                Console.WriteLine("\n----ERROR----\t [" + val.ToString() + "] Número no encontrado!!");
        }

        //Metodo devolverUltimoValor: Regresa el valor de la cola.
        public int devolverUltimoValor() //No recibe nada.
        {
            /*Regresa el valor de la cola.*/
            return tail.val;
        }

        //Metodo Quitar: Desencola el ultimo valor de la Lista, en este caso, la cola.
        public void Quitar() //No recibe nada.
        {
            /*Se crea una variable auxiliar de tipo Nodo y se le pasa la referencia de tail.*/
            Nodo aux = tail;
            /*El if valida que la lista no este vacia, de estarlo, no se
             podra desencolar ningun elemento.*/
            if (tail == null)
                Console.WriteLine("\n----ERROR----\tLa lista esta vacia.");
            /*Entrar al else, significa que hay nodos que pueden ser 
             desencolados.*/
            else
            {
                /*Este if valida si el nodo que se va a desencolar, es el
                 unico que queda en la lista, de serlo, tanto head y tail
                 se vuelven a NULL, indicando que la Lista se quedo vacia.*/
                if (aux.sig == aux.ant)
                    head = tail = null;
                /*Entrar al else significa que hay por lo menos dos nodos
                 en la Lista, y las asignaciones a hacer es que al penultimo
                 nodo, ahora apunte a null, y recorremos la cola ese penultimo
                 nodo, perdiendo asi referencia del ultimo nodo.*/
                else
                {
                    aux.ant.sig = null;
                    tail = tail.ant;
                }

            }
            
        }

        //Metodo Imprimir: Imprime la Lista ordenada partiendo de la cabeza a la cola.
        public void Imprimir() //No recibe nada.
        {
            /*Se crea una variable auxiliar que se inicializa en head.*/
            Nodo aux = head;
            Console.Write("\n\tLista:\t[");
            /*Con este while, se va a ir recorriendo la Lista.*/
            while (aux != null)
            {
                /*Este if y else sirven para distinguir de cuando se llega al ultimo
                 elemento de la lista, ya que en este ultimo, no se imprimera la coma
                 para separar a los elementos.*/
                if (aux.sig != null)
                    Console.Write("" + aux.val.ToString() + ", ");
                else
                    Console.Write(aux.val.ToString());
                /*Se recorre aux nodo por nodo*/
                aux = aux.sig;
            }
            Console.Write("]");
        }

        //Metodo Longitud: Calcula el numero total de elementos que posee la Lista.
        public int Longitud() //No recibe nada.
        {
            /*Se crea una variable auxiliar y se inicializa con head.*/
            Nodo aux = head;
            /*Se crea el contador de los elementos de la Lista, 
             inicializado con 1.*/
            int i = 1;
            /*Se va recorriendo la Lista.*/
            while (aux.sig != null)
            {
                i++;
                aux = aux.sig;
            }
            /*Regresa el numero de elementos que posee la Lista.*/
            return i;
        }
    }
}

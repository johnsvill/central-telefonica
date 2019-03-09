using System;
using static System.Console; //es para no estar escribiendo la palabra console
using CentralTelefonica.Entidades;
using System.Collections.Generic; // Se importan la libreria
using CentralTelefonica.Util;
namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        //constante
        private const float precioUnoDepartamental = 0.65f; //se realiza el cast de double a float
        private const float precioDosDepartamental = 0.85f; //Una constante nunca va a cambiar de valor
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 0.49f;

        //Almacenar una coleccion a nivel de la clase (Listas Genericas)
        public List<Llamada> ListaDeLlamadas { get; set; }//Encapsulamiento *Cuando no utilizar este tipo de encapsulamiento cuando no se va a validar que este vacia etc

        public MenuPrincipal()
        {
            this.ListaDeLlamadas = new List<Llamada>();
        }
        public void MostrarMenu()
        {
            int opcion = 100;
            do
            {
                try
                {
                    //Sentencia de control do..While
                    //console.writeLine("1. Registrar llamada Local");
                    WriteLine("1. Registrar llamada Local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. Costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamdas departamentales");
                    WriteLine("5. Costo total de las llamdas");
                    WriteLine("6. Mostrar Resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opción===>");
                    string valor = ReadLine();
                    opcion = Convert.ToInt16(valor);
                    //Sentencias de Control if
                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }

                    else if (opcion == 6)
                    {
                        MostarDetalleForEach();
                    }
                }
                catch (Exception e)
                {
                    throw new OpcionMenuExcepcion();
                }
            } while (opcion != 0);
        }

        //Metodo
        public void RegistrarLlamada(int opcion)
        { //crear parametro
          //Crear variables a nivel de la clase
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
            //string tipo = "";
            Llamada llamada = null;
            WriteLine("Ingrese el número de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el número de destino");
            numeroDestino = ReadLine();
            WriteLine("Duración de la llamada");
            duracion = ReadLine();

            /*WriteLine("Tipo de Llamada: \n1. \"Local \"\n2. Depto"); //caracter salto de linea o de escape
            tipo = ReadLine();*/

            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0; //Regla de Negocio Franja 0: L(6:00)-V(21:59)  Franja 1: L(22:00) - V(5:59) Franja 3: V(22:00) - L (5:59)

            }
            else
            {
                WriteLine("Tipo de llamada no registrada");
            }
            this.ListaDeLlamadas.Add(llamada);
        }
        public void MostrarDetalleWhile()
        {
            int i = 0;
            while (this.ListaDeLlamadas.Count > i)
            {
                WriteLine(this.ListaDeLlamadas[i]);
                //i = i + 1;
                //i+=1;
                i++;
            }
        }
        public void MostrarDetalleDoWhile()
        {
            int i = 0;
            do
            {
                WriteLine(this.ListaDeLlamadas[i]);
                i++;
            } while (this.ListaDeLlamadas.Count > i);
        }
        public void MostrarDetalleFor()
        {

            for (int i = 0; i < this.ListaDeLlamadas.Count; i++)
            {
                WriteLine(this.ListaDeLlamadas[i]);
            }
        }
        public void MostarDetalleForEach()
        {
            foreach (var llamada in this.ListaDeLlamadas)
            {
                WriteLine(llamada);
            }
       }
    }    
}

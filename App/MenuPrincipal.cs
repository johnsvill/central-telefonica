using System;
using static System.Console; //Namespace para la consola
using CentralTelefonica.Entidades;
using System.Collections.Generic; //Colecciones genéricas y concurrentes
namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        private const float precioUnoDepartamental = 0.65f; //Se pone "f" para definir un float
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 0.49f;
        public List<Llamada> ListaDeLlamadas {get; set;} //Propiedad
        public void MostrarMenu()
        {
            var opcion = 0; //Es un tipo de variable estandar q va a depender de la asignación
            do
            {
                WriteLine("1. Registrar llamada local1");
                WriteLine("2. Registrar llamada departamental1");
                WriteLine("3. Costo total de las llamadas locales locales");
                WriteLine("4. Costo total de las llamadas departamentales");
                WriteLine("5. Costo total de las llamadas");
                WriteLine("0. Salir");
                WriteLine("Ingrese su opción===>");
                string valor = ReadLine();
                opcion = Convert.ToInt16(valor); //Unboxing, "ToInt16" se está utilizando un método estático q no es necesario instanciar
                if(opcion == 1)
                {
                    RegistrarLlamada(opcion); //No está devolviendo ningún valor
                }
               
            }while(opcion != 0);
        }
        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = ""; //Son variables a nivel de la clase
            string numeroDestino = ""; //Son variables a nivel de la clase
            string duracion = ""; //Son variables a nivel de la clase
           /*  string tipo = ""; //Son variables a nivel de la clase*/
           Llamada llamada = null;
            WriteLine("Ingrese el número de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el número de destino");
            numeroDestino = ReadLine();
            WriteLine("Duración de la llamada");
            duracion = ReadLine();
           /*  WriteLine("Tipo de llamada: \n1. \"Local\"\n2. Depto"); 
           //  \"Local\" para imprimier las comillas*/

           //SENTENCIAS DE CONTROL
            if(opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen,numeroDestino,Convert.ToDouble(duracion));
                /* llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);*/
                ((LlamadaLocal)llamada).Precio = precioLocal; //Casteo

            }else if(opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen,numeroDestino,Convert.ToDouble(duracion));

             /* llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);*/
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0;

            }else
            {
                WriteLine("Tipo de llamada no registrado");
            }
        }
    }
}
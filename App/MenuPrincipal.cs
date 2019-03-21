using System;
using static System.Console; //Namespace para la consola
using CentralTelefonica.Entidades;
using System.Collections.Generic; //Colecciones genéricas y concurrentes
using CentralTelefonica.Util;
namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        //constante
        private const float precioUnoDepartamental = 0.65f; //Se realiza el cast de double a float y se pone "f" para q reconozca el float
        private const float precioDosDepartamental = 0.85f; //Una constante nunca va a cambiar de valor
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 1.25f;

        //Almacenar una colección a nivel de la clase (Listas Genéricas)
        public List<Llamada> ListaDeLlamadas { get; set; }//Opción 1 ver foto
        //Encapsulamiento *Cuando no utilizar este tipo de encapsulamiento cuando no se va a validar que este vacia etc
        public MenuPrincipal()
        {
            this.ListaDeLlamadas = new List<Llamada>();
        }
        public void MostrarMenu()
        {
            int opcion = 100;//Es un tipo de variable estándar q va a depender de la asignación
            do
            {
                try
                {
                    WriteLine("1. Registrar llamada Local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. Costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamdas departamentales");
                    WriteLine("5. Costo total de las llamdas");
                    WriteLine("6. Mostrar Resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opción===>");
                    string valor = ReadLine();
                    if (EsNumero(valor) == true)
                    {
                        opcion = Convert.ToInt16(valor);//Unboxing, "ToInt16" se está utilizando un método estático q no es necesario instanciar
                    }
                    /* opcion = Convert.ToInt16(valor);*/ 
                     //SENTENCIAS DE CONTROL
                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);//No está devolviendo ningún valor
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);//No está devolviendo ningún valor
                    }
                    else if (opcion == 3)
                    {
                        MostrarCostoLlamadasLocales();//No está devolviendo ningún valor
                    }
                    else if (opcion == 6)
                    {
                        MostarDetalle();
                    }
                }
                catch (OpcionMenuExcepcion e) // Ver foto
                {
                    WriteLine(e.Message);
                }
            } while (opcion != 0);
        }
        public Boolean EsNumero(string valor)
        {
            Boolean resultado = false;
            try
            {
                int numero = Convert.ToInt16(valor);
                resultado = true;
            }
            catch (Exception e)
            {
                throw new OpcionMenuExcepcion();
            }
            return resultado;
        }
        //Método
        public void RegistrarLlamada(int opcion)
        { //Crear parametro
            string numeroOrigen = "";//Son variables a nivel de la clase
            string numeroDestino = "";//Son variables a nivel de la clase
            string duracion = "";//Son variables a nivel de la clase
            //String tipo = "";
            Llamada llamada = null;
            WriteLine("Ingrese el número de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el número de destino");
            numeroDestino = ReadLine();
            WriteLine("Duración de la llamada");
            duracion = ReadLine();

            /*WriteLine("Tipo de Llamada: \n1. \"Local \"\n2. Depto"); //Caracter salto de linea o de escape
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
        /*  public void MostrarDetalleWhile()
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
         }*/
        public void MostarDetalle()
        {
            foreach (var llamada in this.ListaDeLlamadas)//Para recorrer todas las posiciones sin verificar la última posición
            {
                WriteLine(llamada);
            }
        }
        public void MostrarCostoLlamadasLocales()
        {
            double costoTotal = 0.0;
            double tiempoLlamada = 0;
            /*Llamada validar = new LlamadaLocal();*/
            foreach (var elemento in ListaDeLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaLocal))//Se está comparando no sólo el tipo sino de la instancia de la q fue creada
                 //GetType me devuelve 2 formas: Llamada y LlamadaLocal, se está obligando al método a q compare las 2 formas q tiene
                {
                    tiempoLlamada += elemento.Duracion;
                    costoTotal += elemento.CalcularPrecio();//Se está invocando el método q está en la clase hija, solo se manda a llamar la implementación del método
                }
            }
            WriteLine($"Costo minuto: {precioLocal}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamada}");
            WriteLine($"Costo total: {costoTotal}");
        }
        public void MostrarDetalleLlamadasDepto()
        {
            double tiempoLlamadaFranjaUno = 0;
            double tiempoLlamadaFranjaDos = 0;
            double tiempoLlamadaFranjaTres = 0;
            double costoTotalfranjaUno = 0;
            double costoTotalfranjaDos = 0;
            double costoTotalfranjaTres = 0;
            foreach (var elemento in ListaDeLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaDepartamental))
                {
                    switch (((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                            tiempoLlamadaFranjaUno += elemento.Duracion;
                            costoTotalfranjaUno += elemento.CalcularPrecio();
                            break;
                        case 1:
                            tiempoLlamadaFranjaDos += elemento.Duracion;
                            costoTotalfranjaDos += elemento.CalcularPrecio();
                            break;
                        case 2:
                            tiempoLlamadaFranjaTres += elemento.Duracion;
                            costoTotalfranjaTres += elemento.CalcularPrecio();
                            break;
                    }
                }
            }
            WriteLine("Fraja 1: ");
            WriteLine($"Costo por minuto: {precioUnoDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaUno}");
            WriteLine($"Costo total: {costoTotalfranjaUno}");

            WriteLine("Franja 2: ");
            WriteLine($"Costo por minuto: {precioDosDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaDos}");
            WriteLine($"Costo total: {costoTotalfranjaDos}");

            WriteLine("Franja 3: ");
            WriteLine($"Costo por minuto: {precioTresDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaTres}");
            WriteLine($"Costo total: {costoTotalfranjaTres}");
        }
        public int calcularFranja(DateTime fecha)
        {
            int resultado = -1;
            return resultado; //0,1,2
        }
    }
}

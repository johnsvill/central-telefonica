﻿using System;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.App;
using CentralTelefonica.Util;

namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.MostrarMenu();
            }
            catch(OpcionMenuExcepcion e)
            {
                Console.WriteLine(e.Message);
            }
            /* Llamada llamadaDepto = new LlamadaDepartamental();
              llamadaDepto.NumeroDestino = "123";
              llamadaDepto.NumeroOrigen = "456";
              ((LlamadaDepartamental)llamadaDepto).Franja = 0;
              ((LlamadaDepartamental)llamadaDepto).Duracion = 10;
              ((LlamadaDepartamental)llamadaDepto).PrecioUno = 1.5;

              Llamada llamadaLocal = new LlamadaLocal();
              llamadaLocal.NumeroDestino = "789";
              llamadaLocal.NumeroOrigen = "135";
              llamadaLocal.Duracion = 5;
              ((LlamadaLocal)llamadaLocal).Precio = 0.96;

              Llamada otraLocal = new LlamadaLocal();
              otraLocal.NumeroDestino = "111";
              otraLocal.NumeroOrigen = "222";
              otraLocal.Duracion = 25;
              ((LlamadaLocal)otraLocal).Precio = 0.96;

              List<Llamada> llamadasRealizadas = new List<Llamada>(); //COLECCIÓN 
              llamadasRealizadas.Add(llamadaDepto);
              llamadasRealizadas.Add(llamadaLocal);
              llamadasRealizadas.Add(otraLocal);
              foreach (Llamada item in llamadasRealizadas)
              { 
                  if (item is LlamadaLocal)
                  {
                       Console.WriteLine($"Llamada Local ({item}) Precio: {item.CalcularPrecio()}"); //Interpolación
                  }
                  else if (item is LlamadaDepartamental)
                  {
                        Console.WriteLine($"Llamada Depto ({item}) Precio: {item.CalcularPrecio()}"); //Interpolación
                  }     
              }*/
            /*Console.ReadKey(); */
        }
    }
}

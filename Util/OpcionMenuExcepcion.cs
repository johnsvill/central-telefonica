using System;

namespace CentralTelefonica.Util
{
    public class OpcionMenuExcepcion : Exception
    {
        private string message = "Error, debe de ingresar un número no un caracter";
        public override string Message
        {
            get { return message;}
        }      
    }
}
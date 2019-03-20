using System;

namespace CentralTelefonica.Util
{
    public class OpcionMenuExcepcion : Exception
    {
        private string message = "\"ERROR\", debe de ingresar una opción válida";
        public override string Message
        {
            get { return message;}
        }      
    }
}
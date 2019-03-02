namespace CentralTelefonica.Entidades
{
    public class LlamadaLocal : Llamada
    {
        private double precio;
        public double Precio
        {
            get { return precio;}
            set { precio = value;}
        }
        public LlamadaLocal() //Constructor nulo o por defecto
        {

        }
        //Programación Funcional
        public LlamadaLocal(string numeroOrigen, string numeroDestino, double duracion) =>
           (base.NumeroOrigen, base.NumeroDestino, base.Duracion) = //Propiedades de la clase
             (numeroOrigen,numeroDestino,duracion); //Parámetros q recibe el constructor
        
        public override double CalcularPrecio()
        {
            return this.Precio * this.Duracion;
        }
    }
}
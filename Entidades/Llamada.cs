namespace CentralTelefonica.Entidades
{
    public abstract class Llamada
    {
        private string numeroOrigen;
        public string NumeroOrigen
        {
            get { return numeroOrigen;}
            set { numeroOrigen = value;}
        } 
        private string numeroDestino;
        public string NumeroDestino
        {
            get { return numeroDestino;}
            set { numeroDestino = value;}
        }
        private double duracion;
        public double Duracion
        {
            get { return duracion;}
            set { duracion = value;}
        }
        public Llamada() //Constructor nulo o por defecto
        {

        }
        //Programación Funcional
        public Llamada(string numeroOrigen, string numeroDestino, double duracion) 
          => (NumeroOrigen,NumeroDestino,Duracion) = //Propiedades de la clase
                (numeroOrigen,numeroDestino,duracion); //Parámetros q recibe el constructor
        public abstract double CalcularPrecio();
        public override string ToString()//Sobreescribir
        {
            return $" #Origen: {this.numeroOrigen} - #Destino: {this.numeroDestino} - Duración: {this.duracion}";
        }
    }
}
namespace CentralTelefonica.Entidades
{
    public class LlamadaDepartamental : Llamada
    {
        private double precioUno;
        public double PrecioUno
        {
            get { return precioUno;}
            set { precioUno = value;}
        }

        private double precioDos;
        public double PrecioDos
        {
            get { return precioDos;}
            set { precioDos = value;}
        }

        private double precioTres;
        public double PrecioTres
        {
            get { return precioTres;}
            set { precioTres = value;}
        }

        private int franja;
        public int Franja
        {
            get { return franja;}
            set { franja = value;}
        }
        
        public override double CalcularPrecio(){
            double resultado = 0;
            if(this.Franja == 0)
            {
                resultado = this.precioUno * this.Duracion;
            }
            else if(this.Franja == 1)
            {
                resultado = this.PrecioDos * this.Duracion;
            }
            else if(this.Franja == 2)
            {
                resultado = this.precioTres * this.Duracion;
            }
            return resultado;
        }  
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProgramacionII.Classes
{
    public class Croupier //Nuestro cerebro
    {
        private int elegido;
        private Ruleta ruleta;

        public int Elegido
        {
            get { return elegido; }
            set { elegido = value; }
        }
        
        public Ruleta Ruleta
        {
            get { return ruleta; }
            set { ruleta = value; }
        }

        public void Inicializar()
        {
            Ruleta = new Ruleta();
        }

        public int Lanzar()
        {
            Random rand = new Random();
            Elegido = rand.Next(0, 37);
            return Elegido;
        }

        public double Pagar()
        {
            double monto = 0;
            double perdida = 0;
            Boolean gano = false;
            List<Apuesta> apuestas = ruleta.apuestas;
            foreach (Apuesta apuesta in ruleta.apuestas)
            {

                foreach (Casillero numero in apuesta.Numeros)
                {
                    if (numero.Valor < 37) //Es un numero
                    {
                        if (numero.Valor == Elegido)
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }
                    }                        
                    else //No es un numero
                    {

                    }
                }
                if (!gano)
                    perdida += apuesta.Dinero;
                else
                    gano = false;
            }

            //monto = 0 -->Perdio todo
                //Hay que descontarle 
            //Monto > 0 -->Gano algo o todo.  ---> "Monto tiene todo el dinero el tipo"

            return monto - perdida;
        }
    }
}

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

        public void Inicializar()
        {
            ruleta = new Ruleta();
        }

        public int Lanzar()
        {
            Random rand = new Random();
            elegido = rand.Next(0, 37);
            return elegido;
        }

        public double Pagar(Ruleta ruleta)
        {

            return 2;
        }
    }
}

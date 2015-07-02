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
        private Player jugador;
        private List<int> col1 = new List<int>(new int[] { 1, 3, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 });
        private List<int> col2 = new List<int>(new int[] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 });

        public Croupier(Player jugador) 
        {
            Jugador = jugador;
            Inicializar();
        }

        public int Elegido
        {
            get { return elegido; }
            set { elegido = value; }
        }

        public Player Jugador
        {
            get { return jugador; }
            set { jugador = value; }
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

        public int Pagar()
        {
            int monto = 0;
            int perdida = 0;
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
                        //Par Impar
                        if ((numero.Valor == 37 && Elegido %2 == 0) || (numero.Valor == 38 && Elegido %2 != 0))
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }

                        //Color
                        if ((numero.Valor == 39 && ruleta.tablero[Elegido].Color == "Rojo") || (numero.Valor == 40 && ruleta.tablero[Elegido].Color == "Negro"))
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }
                        
                        //Docena
                        if((numero.Valor == 41 && (Elegido>0 && Elegido <13)) || 
                            (numero.Valor == 42 && (Elegido>12 && Elegido <25)) || 
                            (numero.Valor == 43 && (Elegido>24 && Elegido <37))) 
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }

                        // 1-18 o 19-36
                        if (numero.Valor == 44 && (Elegido > 0 || Elegido < 19) || numero.Valor == 45 && (Elegido > 18 || Elegido < 37)) 
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }

                        //Columnas
                        if ((numero.Valor == 46 && col1.Contains(Elegido)) ||
                            (numero.Valor == 47 && col2.Contains(Elegido)) ||
                            (numero.Valor == 48 && Elegido % 3 == 0))
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }
                    }
                }
                if (!gano)
                    perdida += apuesta.Dinero;
                else
                    gano = false;
            }
            ruleta.apuestas.Clear();
            return monto - perdida;
        }
    }
}

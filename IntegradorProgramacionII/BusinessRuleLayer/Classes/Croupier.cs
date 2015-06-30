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
        List<Apuesta> apuesta = new List<Apuesta>();

        public List<Apuesta> Apuesta
        {
            get { return apuesta; }
            set { apuesta = value; }
        }

        public Croupier(Player jugador) 
        {
            Jugador = jugador;
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

        public double Pagar()
        {
            double monto = 0;
            double perdida = 0;
            Boolean gano = false;

            foreach (Apuesta apuesta in Apuesta)
            {

                 if (apuesta.Numero.Valor < 37) //Es un numero
                    {
                        if (apuesta.Numero.Valor == Elegido)
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
                        if ((apuesta.Numero.Valor == 37 && Elegido %2 == 0) || (apuesta.Numero.Valor == 38 && Elegido %2 != 0))
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }

                        //Color
                        if ((apuesta.Numero.Valor == 39 && ruleta.tablero[Elegido].Color == "Rojo") || (apuesta.Numero.Valor == 40 && ruleta.tablero[Elegido].Color == "Negro"))
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }
                        
                        //Docena
                        if((apuesta.Numero.Valor == 41 && (Elegido>0 && Elegido <13)) || 
                            (apuesta.Numero.Valor == 42 && (Elegido>12 && Elegido <25)) || 
                            (apuesta.Numero.Valor == 43 && (Elegido>24 && Elegido <37))) 
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }

                        // 1-18 o 19-36
                        if (apuesta.Numero.Valor == 44 && (Elegido > 0 || Elegido < 19) || apuesta.Numero.Valor == 45 && (Elegido > 18 || Elegido < 37)) 
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }

                        //Columnas
                        if ((apuesta.Numero.Valor == 46 && col1.Contains(Elegido)) ||
                            (apuesta.Numero.Valor == 47 && col2.Contains(Elegido)) ||
                            (apuesta.Numero.Valor == 48 && Elegido % 3 == 0))
                        {
                            //Pagar
                            monto += apuesta.Dinero + (apuesta.Modalidad.Multiplicador * apuesta.Dinero);
                            gano = true;
                            break;
                        }
                    }
                 if (!gano)
                     perdida += apuesta.Dinero;
                 else
                     gano = false;
            }
            Jugador.Efectivo = 66666; //pruebaaa
            double vm = monto - perdida;
            return  vm;

        }

        }
    }


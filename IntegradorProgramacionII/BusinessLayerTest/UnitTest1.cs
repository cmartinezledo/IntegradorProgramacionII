using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IntegradorProgramacionII.Classes;
using System.Collections.Generic;

namespace BusinessLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        Croupier pepe = new Croupier(new Player());
        Ruleta ruleta = new Ruleta(); 
        

        [TestMethod]
        [TestCategory("Casilleros")]
        public void Casillero3EsRojo()
        {
            List<Casillero> casilleros = new List<Casillero>();
            casilleros.Add(ruleta.tablero[3]);
            
            //Ficha
                //Dinero en fichas
            
            //Modalidad
            Modalidad modalidad = new Modalidad("Pleno");

            Player p = new Player();

            Apuesta a = new Apuesta(casilleros, 500, modalidad, p);
            
            //Testing
            Assert.IsNotNull(a);
            Assert.AreEqual(a.Modalidad.Nombre, "Pleno");
            Assert.AreEqual(a.Numeros.Count, 1);
            foreach (Casillero num in a.Numeros)
	        {
                Assert.AreEqual(3, num.Valor);
                Assert.AreEqual("Rojo", num.Color);
	        }          

        }

        [TestMethod]
        [TestCategory("Casilleros")]
        public void Casillero2EsNegro()
        {
            List<Casillero> casilleros = new List<Casillero>();
            casilleros.Add(ruleta.tablero[2]);
            
            //Ficha
            //Dinero en fichas

            //Modalidad
            Modalidad modalidad = new Modalidad("Pleno");

            Player p = new Player();

            Apuesta a = new Apuesta(casilleros, 500, modalidad, p);

            //Testing
            Assert.IsNotNull(a);
            Assert.AreEqual(a.Modalidad.Nombre, "Pleno");
            Assert.AreEqual(a.Numeros.Count, 1);
            foreach (Casillero num in a.Numeros)
            {
                Assert.AreEqual(2, num.Valor);
                Assert.AreEqual("Negro", num.Color);
            }
        }

        [TestMethod]
        [TestCategory("Apuestas")]
        public void ApuestaPleno()
        {
            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[2]);
            
            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[14]);
            
            //Modalidad
            Modalidad modalidad = new Modalidad("Pleno");
            
            //Jugador
            Player p = new Player();
            
            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 200, modalidad, p);
            
            ruleta.Apostar(a);
            ruleta.Apostar(b);
            //Testing
            double total=0;
            foreach (Apuesta bet in ruleta.apuestas)
            {
                Assert.AreEqual("Pleno", bet.Modalidad.Nombre);
                total += bet.Dinero;
            }
            Assert.AreEqual(700, total);
            
        }

        [TestMethod]
        [TestCategory("Gano-Pleno")]
        public void GanoPleno()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[2]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[14]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Pleno");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 200, modalidad, p);
            ruleta.Apostar(a);
            ruleta.Apostar(b);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 2;

            Assert.AreEqual(17800.0,pepe.Pagar());    
        }

        [TestMethod]
        [TestCategory("Perdio-Pleno")]
        public void PerdioPleno()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[2]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[14]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Pleno");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 200, modalidad, p);
            ruleta.Apostar(a);
            ruleta.Apostar(b);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 4;

            Assert.AreEqual(-700.0, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Gano-Semi")]
        public void GanoSemi()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[2]);
            casillerosA.Add(ruleta.tablero[3]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[14]);
            casillerosB.Add(ruleta.tablero[15]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Semi");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 200, modalidad, p);
            ruleta.Apostar(a);
            ruleta.Apostar(b);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 2;

            Assert.AreEqual(8800.0, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Perdio-Semi")]
        public void PerdioSemi()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[2]);
            casillerosA.Add(ruleta.tablero[3]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[14]);
            casillerosB.Add(ruleta.tablero[15]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Semi");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 200, modalidad, p);
            ruleta.Apostar(a);
            ruleta.Apostar(b);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 21;

            Assert.AreEqual(-700.0, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Perdio-Semi | Gano-Pleno")]
        public void PerdioSemiGanoPleno()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[2]);
            casillerosA.Add(ruleta.tablero[3]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[14]);

            //Modalidad
            Modalidad modalidadA = new Modalidad("Semi");
            Modalidad modalidadB = new Modalidad("Pleno");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidadA, p);
            Apuesta b = new Apuesta(casillerosB, 200, modalidadB, p);
            ruleta.Apostar(a);
            ruleta.Apostar(b);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 14;

            // Paga 7000 por el pleno, mas la proia apuesta de 200 y le resta los 500 que aposto al semi! = 6700
            Assert.AreEqual(6700, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Gano-Par")]
        public void GanoPar()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[37]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 2;

            Assert.AreEqual(1000, pepe.Pagar());
        }
        [TestMethod]
        [TestCategory("Perdio-Par")]
        public void PerdioPar()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[37]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 3;

            Assert.AreEqual(-500, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Gano-Impar")]
        public void GanoImpar()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[38]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 3;

            Assert.AreEqual(1000, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Perdio-Impar")]
        public void PerdioImpar()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[38]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 2;

            Assert.AreEqual(-500, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Gano-Rojo")]
        public void GanoRojo()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[39]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 3;

            Assert.AreEqual(1000, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Perdio-Rojo")]
        public void PerdioRojo()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[39]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 2;

            Assert.AreEqual(-500, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Gano-Negro")]
        public void GanoNegro()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[40]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 2;

            Assert.AreEqual(1000, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Perdio-Negro")]
        public void PerdioNegro()
        {

            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[40]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Chances Simples");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            ruleta.Apostar(a);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 3;

            Assert.AreEqual(-500, pepe.Pagar());
        }

        [TestMethod]
        [TestCategory("Apuestas")]
        public void ApuestaDocena()
        {
            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[41]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[42]);
            
            List<Casillero> casillerosC = new List<Casillero>();
            casillerosC.Add(ruleta.tablero[43]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Docena");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 2000, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 500, modalidad, p);
            Apuesta c = new Apuesta(casillerosC, 250, modalidad, p);

            ruleta.Apostar(a);
            ruleta.Apostar(b);
            ruleta.Apostar(c);
            
            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 4;

            Assert.AreEqual(5250, pepe.Pagar());
        }
        [TestMethod]
        [TestCategory("Apuestas")]
        public void ApuestaFilas()
        {
            //Casilleros
            List<Casillero> casillerosA = new List<Casillero>();
            casillerosA.Add(ruleta.tablero[46]);

            List<Casillero> casillerosB = new List<Casillero>();
            casillerosB.Add(ruleta.tablero[47]);

            List<Casillero> casillerosC = new List<Casillero>();
            casillerosC.Add(ruleta.tablero[48]);

            //Modalidad
            Modalidad modalidad = new Modalidad("Columna");

            //Jugador
            Player p = new Player();

            //Apuesta
            Apuesta a = new Apuesta(casillerosA, 500, modalidad, p);
            Apuesta b = new Apuesta(casillerosB, 2000, modalidad, p);
            Apuesta c = new Apuesta(casillerosC, 250, modalidad, p);

            ruleta.Apostar(a);
            ruleta.Apostar(b);
            ruleta.Apostar(c);

            //Asignar Croupier
            pepe.Ruleta = ruleta;
            pepe.Elegido = 5;

            Assert.AreEqual(5250, pepe.Pagar());
        }
    }
}

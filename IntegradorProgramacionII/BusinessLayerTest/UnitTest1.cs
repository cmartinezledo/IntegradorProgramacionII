using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IntegradorProgramacionII.Classes;
using System.Collections.Generic;

namespace BusinessLayerTest
{
    [TestClass]
    public class UnitTest1
    {
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
        [TestCategory("Modalidad")]
        public void MultiplicadorModalidad()
        {
            int apuesta = 3;

            //Modalidad
            Modalidad modalidad1 = new Modalidad("Pleno");
            Modalidad modalidad2 = new Modalidad("Semi");
            Modalidad modalidad3 = new Modalidad("Calle");
            Modalidad modalidad4 = new Modalidad("Cubre");
            Modalidad modalidad5 = new Modalidad("Cuadro");
            Modalidad modalidad6 = new Modalidad("Linea");
            Modalidad modalidad7 = new Modalidad("Columna");
            Modalidad modalidad8 = new Modalidad("Docena");
            Modalidad modalidad9 = new Modalidad("Chances Simples");
            Modalidad modalidad10 = new Modalidad("Doble Columna");
            Modalidad modalidad11 = new Modalidad("Doble Docena");

            //Testing
            Assert.AreEqual(35, modalidad1.Multiplicador);
            Assert.AreEqual(17, modalidad2.Multiplicador);
            Assert.AreEqual(11, modalidad3.Multiplicador);
            Assert.AreEqual(11, modalidad4.Multiplicador);
            Assert.AreEqual(8, modalidad5.Multiplicador);
            Assert.AreEqual(5, modalidad6.Multiplicador);
            Assert.AreEqual(2, modalidad7.Multiplicador);
            Assert.AreEqual(2, modalidad8.Multiplicador);
            Assert.AreEqual(1, modalidad9.Multiplicador);
            Assert.AreEqual(1/2, modalidad10.Multiplicador);
            Assert.AreEqual(1/2, modalidad11.Multiplicador);

            Assert.AreEqual(33, apuesta*modalidad4.Multiplicador);
            Assert.AreEqual(3, apuesta*modalidad9.Multiplicador);
            Assert.AreEqual(2/3, apuesta*modalidad11.Multiplicador);

        } 
    
    }
}

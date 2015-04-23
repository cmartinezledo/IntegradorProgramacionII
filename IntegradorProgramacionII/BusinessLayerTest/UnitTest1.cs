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
    
    
    }
}

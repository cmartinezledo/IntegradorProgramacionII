using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IntegradorProgramacionII.Classes;
using System.Collections.Generic;

namespace BusinessLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Pleno()
        {
            Ruleta ruleta = new Ruleta();
            
            List<Casillero> casilleros = new List<Casillero>();
            casilleros.Add(ruleta.tablero[3]);
            
            //Ficha
            List<Ficha> fichas = new List<Ficha>();
            Ficha ficha = new Ficha();
            fichas.Add(ficha);
            
            //Modalidad
            Modalidad modalidad = new Modalidad("Pleno");

            Apuesta a = new Apuesta(casilleros, fichas, modalidad);
            
            //Testing
            Assert.IsNotNull(a);
            Assert.AreEqual(a.Modalidad.Nombre, "Pleno");
            Assert.AreEqual(a.Numeros.Count, 1);
            foreach (Casillero num in a.Numeros)
	        {
                Assert.AreEqual(num.Valor, 3);
                Assert.AreEqual(num.Color, "Rojo");
	        }
            

            
        }
    }
}

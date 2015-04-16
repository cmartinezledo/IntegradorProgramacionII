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
        public void TestMethod1()
        {
            Ruleta ruleta = new Ruleta();
            
            List<Casillero> casilleros = new List<Casillero>();
            casilleros.Add(ruleta.tablero[3]);
            //Ficha 


            Apuesta a = new Apuesta(casilleros, null, null);
            Assert.IsNotNull(a);
            
            //ruleta.

            
        }
    }
}

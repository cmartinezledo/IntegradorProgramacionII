using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using IntegradorProgramacionII.Classes;

namespace DataAccessLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        [TestCategory("Player")]
        public void ABPlayer()
        {
            PlayerDAO DAO = new PlayerDAO();
            Players player = new Players();

            player.User = "pepe";
            player.Pass = "1234";
            player.Nombre = "Pedro";
            player.Apellido = "Otero";
            player.Email = "pedro.otero@gmail.com";
            player.Avatar = 6;

            DAO.AltaPlayer(player);

            player = DAO.ValidarLogin("Pepe", "1234");
            Assert.IsNotNull(player);

            DAO.BajaPlayer(player);
        }
        
    }
}

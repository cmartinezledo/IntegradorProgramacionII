using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
namespace DataAccessLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Conexion")]
        public void ProbarConexion()
        {
            PlayerDAO DAO = new PlayerDAO();
            Player player = DAO.ValidarLogin("usertest", "passtest");
            Assert.IsNotNull(player);
            Assert.AreEqual(1, player.Id);
        }

        [TestMethod]
        [TestCategory("Alta")]
        public void AltaPlayer()
        {
            PlayerDAO DAO = new PlayerDAO();
            Player player = new Player();
            player.Nombre = "Pepe";
            player.Password = "1234";
            DAO.AltaPlayer(player);

            player = DAO.ValidarLogin("Pepe", "1234");
            Assert.IsNotNull(player);

            DAO.BajaPlayer(player);
        }
        
    }
}

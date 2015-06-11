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
        
    }
}

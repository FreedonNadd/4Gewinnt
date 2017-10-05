using _4GewinntLib.Classes;
using _4GewinntLib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;

namespace _4GewinntLibTests
{
    [TestClass]
    public class PlayerTests
    {
        IPlayer testCase;
        [TestInitialize]
        public void InitPlayer()
        {
            testCase = new Player("Foo", Color.FromRgb(255, 0, 0));
        }

        [TestMethod]
        public void CreatePlayer()
        {
            Assert.IsNotNull(testCase.Name);
        }

        [TestMethod]
        public void PlayerhasName()
        {
            Assert.AreEqual(testCase.Name, "Foo");
        }

        [TestMethod]
        public void PlayerhasColor()
        {
            Assert.IsNotNull(testCase.PlayerColor);
        }
    }
}

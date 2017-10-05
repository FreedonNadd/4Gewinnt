using _4GewinntLib.Classes;
using _4GewinntLib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4GewinntLibTests
{
    [TestClass]
    public class BoardTests
    {
        IPlayer PlayerA;
        IPlayer PlayerB;
        IBoard board;
        [TestInitialize]
        public void InitializeBoard()
        {
            PlayerA = new Player("A", Color.FromRgb(255, 0, 0));
            PlayerB = new Player("B", Color.FromRgb(0, 255, 0));
            board = new Board(PlayerA, PlayerB);
        }
        [TestMethod]
        public void TestHorizontalWinningCondition()
        {
            board.PlaceStone(0);
            board.PlaceStone(0);

            board.PlaceStone(1);
            board.PlaceStone(1);

            board.PlaceStone(2);
            board.PlaceStone(2);

            board.PlaceStone(3);

            Assert.AreEqual(PlayerA, board.EvaluateWinner());
        }

        [TestMethod]
        public void TestVerticalWinningCondition()
        {
            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(0);

            Assert.AreEqual(PlayerA, board.EvaluateWinner());
        }

        [TestMethod]
        public void TestNoWinnerfound()
        {
            Assert.IsNull(board.EvaluateWinner());
        }

        [TestMethod]
        public void TestHorizontalWinnerDownToUp()
        {
            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(1);
            board.PlaceStone(2);

            board.PlaceStone(2);
            board.PlaceStone(3);

            board.PlaceStone(2);
            board.PlaceStone(3);

            board.PlaceStone(4);
            board.PlaceStone(3);

            board.PlaceStone(3);

            Assert.AreEqual(PlayerA, board.EvaluateWinner());
        }

        [TestMethod]
        public void TestHorizontalWinnerUpToDown()
        {
            board.PlaceStone(3);
            board.PlaceStone(2);

            board.PlaceStone(2);
            board.PlaceStone(1);

            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(1);
            board.PlaceStone(0);

            board.PlaceStone(1);
            board.PlaceStone(0);

            board.PlaceStone(0);

            Assert.AreEqual(PlayerA, board.EvaluateWinner());
        }

        [TestMethod]
        public void TestPlayerBReachesWinningCondition()
        {
            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(0);
            board.PlaceStone(1);

            board.PlaceStone(2);
            board.PlaceStone(1);

            Assert.AreEqual(PlayerB, board.EvaluateWinner());
        }
    }
}

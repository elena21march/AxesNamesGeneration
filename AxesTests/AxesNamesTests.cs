using Microsoft.VisualStudio.TestTools.UnitTesting;
using AxesNamesGeneration;
using System.Collections.Generic;
using System;

namespace AxesTests
{
    [TestClass]
    public class AxesNamesTests
    {
        private HBlock GetHblock(string id, string lluId, int storyNum)
        {
            var random = new Random();
            var llu = new LLU() { Id = lluId };
            List<Level> hblockLevels = new List<Level>();
            for (int i = 0; i < 5; i++)
            {
                Level level;
                if (random.Next(2) > 0)
                    level = new Level() { Llu = llu };
                else
                    level = new Level();

                hblockLevels.Add(level);
            }


            return new HBlock()
            {
                Id = id,
                Levels = hblockLevels,
                StoreyNum = storyNum
            };
        }

        

        [TestMethod]
        public void ComfortBadId()
        {
            var hblock = new HBlock() { Id = "dsfsdf" };
            // Arrange
            string expected = null;
            // Act
            var result = AxesNames.GetAxes(hblock, "Комфорт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ComfortGoodSMIdBadLluId()
        {
            var hblock = GetHblock("S_M_10", "dsfsdf", 15);
            // Arrange
            string expected = null;
            // Act
            var result = AxesNames.GetAxes(hblock, "Комфорт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ComfortT()
        {
            var hblock = GetHblock("S_T_8x5-9RD", "LLU_L_blabla", 15);
            // Arrange
            var expected = "Axes_T_8x5-9RD.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Комфорт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ComfortMS()
        {
            var hblock = GetHblock("S_M_10", "LLU_L_blabla", 15);
            // Arrange
            var expected = "Axes_L_10.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Комфорт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ComfortA()
        {
            var hblock = GetHblock("S_A_7x7-5LC", "LLU_A_blabla", 15);
            // Arrange
            var expected = "Axes_A_7x7-5LC.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Комфорт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ComfortAXL()
        {
            var hblock = GetHblock("S_A_7x7R", "LLU_AXL_blabla", 15);
            // Arrange
            var expected = "Axes_AXL_7x7R.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Комфорт");
            // Assert
            Assert.AreEqual(expected, result);
        }

      

        [TestMethod]
        public void StandardMS()
        {
            var hblock = GetHblock("S_M_9_1288560543", "LLU_AXL_blabla", 17);
            var expected = "Axes_24_9.rvt";
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardMSBadLlu()
        {
            var hblock = GetHblock("S_M_9_1288560543", null, 17);
            var expected = "Axes_24_9.rvt";
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardA()
        {
            // Arrange
            var hblock = GetHblock("S_A_5x9L_5877639571", null, 5);
            var expected = "Axes_A_9_5x9L.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardT()
        {
            // Arrange
            var hblock = GetHblock("S_T_10_1668172726", null, 17);
            var expected = "Axes_T_24_10.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardTx()
        {

            // Arrange
            var hblock = GetHblock("S_T_7x7_9616462263", null, 24);
            var expected = "Axes_T_7x7_24LD.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardNullId()
        {
            // Arrange
            var hblock = GetHblock(null, null, 24);
            string expected = null;
            // Act
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardBadId()
        {
            // Arrange
            var hblock = GetHblock("1288560543", null, 24);
            string expected = null;
            // Act
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StandardNullFloor()
        {
            // Arrange
            var hblock = GetHblock("S_M_9_1288560543", null, 0);
            string expected = "Axes_0_9.rvt";
            // Act
            var result = AxesNames.GetAxes(hblock, "Стандарт");
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

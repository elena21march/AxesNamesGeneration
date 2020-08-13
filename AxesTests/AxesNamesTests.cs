using Microsoft.VisualStudio.TestTools.UnitTesting;
using AxesNamesGeneration;

namespace AxesTests
{
    [TestClass]
    public class AxesNamesTests
    {
        [TestMethod]
        public void TestMethodForMS()
        {
            // Arrange
            var id = "S_M_9_1288560543";
            var floor = 10;
            var expected = "Axes_16_9.rvt";
            // Act
            var result = AxesNames.GenerateAxesName(id,floor);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForA()
        {
            // Arrange
            var id = "S_A_5x9L_5877639571";
            var floor = 5;
            var expected = "Axes_A_9_5x9L.rvt";
            // Act
            var result = AxesNames.GenerateAxesName(id, floor);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForT()
        {
            // Arrange
            var id = "S_T_10_1668172726";
            var floor = 17;
            var expected = "Axes_T_24_10.rvt";
            // Act
            var result = AxesNames.GenerateAxesName(id, floor);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForTx()
        {
            // Arrange
            var id = "S_T_7x7_9616462263";
            var floor = 24;
            var expected = "Axes_T_7x7_24LD.rvt";
            // Act
            var result = AxesNames.GenerateAxesName(id, floor);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForNullId()
        {
            // Arrange
            string id = null;
            var floor = 24;
            string expected = null;
            // Act
            var result = AxesNames.GenerateAxesName(id, floor);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForBadId()
        {
            // Arrange
            string id = "1288560543";
            var floor = 24;
            string expected = null;
            // Act
            var result = AxesNames.GenerateAxesName(id, floor);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForNullFloor()
        {
            // Arrange
            var id = "S_M_9_1288560543";
            var floor = 0;
            string expected = "Axes_0_9.rvt";
            // Act
            var result = AxesNames.GenerateAxesName(id, floor);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

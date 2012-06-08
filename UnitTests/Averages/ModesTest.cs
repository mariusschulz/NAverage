using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class ModesTest
    {
        [TestMethod]
        public void TestIntModesReturnsANonNullNonEmptyModesCollection()
        {
            int[] numbers = { 1, 4, 4, 5 };

            int[] modes = numbers.Modes();

            Assert.IsNotNull(modes);
            Assert.IsTrue(modes.Length > 0);
        }

        [TestMethod]
        public void TestDoubleModesReturnsANonNullNonEmptyModesCollection()
        {
            double[] numbers = { 1.0, 4.0, 4.0, 5.0 };

            double[] modes = numbers.Modes(0);

            Assert.IsNotNull(modes);
            Assert.IsTrue(modes.Length > 0);
        }

        [TestMethod]
        public void TestUnimodalIntDistribution()
        {
            int[] numbers = { 5, 1, 2, 2, 2, 3, 2, 4, 5, 6, 5, 5, 5 };

            int[] modes = numbers.Modes();

            Assert.IsTrue(modes.Length == 1);
            Assert.AreEqual(5, modes[0]);
        }

        [TestMethod]
        public void TestBimodalIntDistribution()
        {
            int[] numbers = { 1, 2, 2, 2, 3, 2, 4, 5, 6, 5, 5, 5 };

            int[] modes = numbers.Modes();
            Array.Sort(modes);

            Assert.IsTrue(modes.Length == 2);

            // Expected modes: 2 and 5
            Assert.AreEqual(2, modes[0]);
            Assert.AreEqual(5, modes[1]);
        }

        [TestMethod]
        public void TestMultimodalIntDistribution()
        {
            int[] numbers = Enumerable.Range(0, 100).ToArray();

            int[] modes = numbers.Modes();
            Array.Sort(modes);

            Assert.IsTrue(modes.Length == numbers.Length);

            for (int i = 0; i < modes.Length; i++)
            {
                Assert.AreEqual(numbers[i], modes[i]);
            }
        }

        [TestMethod]
        public void TestUnimodalDoubleDistribution()
        {
            double[] numbers = { 4.0, 5.0, 4.0, 2.0, 5.1 };

            double[] modes = numbers.Modes(0.00001);

            Assert.IsTrue(modes.Length == 1);
            Assert.AreEqual(4.0, modes[0]);
        }

        [TestMethod]
        public void TestBimodalDoubleDistribution()
        {
            double[] numbers = { 4.0, 5.0, 4.0, 2.0, 5.1, 5.0 };

            double[] modes = numbers.Modes(0.00001);
            Array.Sort(modes);

            Assert.IsTrue(modes.Length == 2);
            Assert.AreEqual(4.0, modes[0]);
            Assert.AreEqual(5.0, modes[1]);
        }

        [TestMethod]
        public void TestMultimodalDoubleDistribution()
        {
            double[] numbers = { 1.1, 2.2, 3.3, 4.4 };

            double[] modes = numbers.Modes(1);
            Array.Sort(modes);

            Assert.IsTrue(modes.Length == 4);
            Assert.AreEqual(1.1, modes[0]);
            Assert.AreEqual(2.2, modes[1]);
            Assert.AreEqual(3.3, modes[2]);
            Assert.AreEqual(4.4, modes[3]);
        }

        [TestMethod]
        public void TestModeOfNegativeNumbersCollection()
        {
            double[] numbers = { -500, -508, 400, -50, -58, -520 };

            double[] modes = numbers.Modes(8);
            Array.Sort(modes);

            Assert.IsTrue(modes.Length == 2);
            Assert.AreEqual(-504, modes[0]);
            Assert.AreEqual(-54, modes[1]);
        }

        [TestMethod]
        public void TestModesOfNullCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(CalculateModesOfNullCollection);
        }

        private static void CalculateModesOfNullCollection()
        {
            int[] numbers = null;

            numbers.Modes();
        }

        [TestMethod]
        public void TestModesOfEmptyCollectionThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(
                CalculateModesOfEmptyCollection);
        }

        private static void CalculateModesOfEmptyCollection()
        {
            int[] numbers = { };

            numbers.Modes();
        }
    }
}

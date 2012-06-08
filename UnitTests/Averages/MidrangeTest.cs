using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class MidrangeTest
    {
        [TestMethod]
        public void TestMidrangeOfNullCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(CalculateMidrangeOfNullCollection);
        }

        private static void CalculateMidrangeOfNullCollection()
        {
            double[] numbers = null;

            numbers.Midrange();
        }

        [TestMethod]
        public void TestMidrangeOfEmptyCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(
                CalculateMidrangeOfEmptyCollection);
        }

        private static void CalculateMidrangeOfEmptyCollection()
        {
            double[] numbers = { };

            numbers.Midrange();
        }

        [TestMethod]
        public void TestMidrangeOfExampleCollection()
        {
            double[] numbers = { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1, 0 };

            // Expected midrange: (6 + 0) / 2 = 3
            const double expectedMidrange = 3;
            double actualMidrange = numbers.Midrange();

            Assert.AreEqual(expectedMidrange, actualMidrange);
        }

        [TestMethod]
        public void TestMidrangeOfExampleCollectionContainingNegativeNumbers()
        {
            double[] numbers = { -5, 1, 5, 7 };

            // Expected midrange: (-5 + 7) / 2 = 1
            const double expectedMidrange = 1;
            double actualMidrange = numbers.Midrange();

            Assert.AreEqual(expectedMidrange, actualMidrange);
        }
    }
}

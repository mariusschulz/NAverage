using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class WinsorizedMeanTest
    {
        [TestMethod]
        public void TestWinsorizedMeanOfNullCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(
                CalculateWinsorizedMeanOfNullCollection);
        }

        private static void CalculateWinsorizedMeanOfNullCollection()
        {
            double[] numbers = null;

            numbers.WinsorizedMean(0.1);
        }

        [TestMethod]
        public void TestWinsorizedMeanOfEmptyCollectionThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(
                CalculateWinsorizedMeanOfEmptyCollection);
        }

        private static void CalculateWinsorizedMeanOfEmptyCollection()
        {
            double[] numbers = { };

            numbers.WinsorizedMean(0.1);
        }

        [TestMethod]
        public void TestWinsorizedMeanExample()
        {
            double[] numbers = { 1, 14, 15, 17, 15, 13, 14, 28, 27 };

            const double expectedWinsorizedMean = 17.22222222222;
            double actualWinsorizedMean = numbers.WinsorizedMean(0.15);

            Assert.AreEqual(expectedWinsorizedMean, actualWinsorizedMean, 0.0001);
        }
    }
}

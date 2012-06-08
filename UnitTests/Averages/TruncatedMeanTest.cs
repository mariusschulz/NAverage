using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class TruncatedMeanTest
    {
        [TestMethod]
        public void TestTruncatedMeanOfNullCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(
                CalculateTruncatedMeanOfNullCollection);
        }

        private static void CalculateTruncatedMeanOfNullCollection()
        {
            double[] numbers = null;

            numbers.TruncatedMean(0.1);
        }

        [TestMethod]
        public void TestTruncatedMeanOfEmptyCollectionThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(
                CalculateTruncatedMeanOfEmptyCollection);
        }

        private static void CalculateTruncatedMeanOfEmptyCollection()
        {
            double[] numbers = { };

            numbers.TruncatedMean(0.1);
        }

        [TestMethod]
        public void TestPercentageToDiscardSmallerThanOrEqualToZeroThrowsArgumentException()
        {
            ExceptionAssert.Throws<ArgumentException>(
                CalculateTruncatedMeanWithPercentageToDiscardSmallerThanOrEqualToZero);
        }

        private static void CalculateTruncatedMeanWithPercentageToDiscardSmallerThanOrEqualToZero()
        {
            double[] numbers = { 1, 2, 3, 4, 5 };

            numbers.TruncatedMean(0);
        }

        [TestMethod]
        public void TestPercentageToDiscardGreaterThanOrEqualToFiftyThrowsArgumentException()
        {
            ExceptionAssert.Throws<ArgumentException>(
                CalculateTruncatedMeanWithPercentageToDiscardGreaterThanOrEqualToFifty);
        }

        private static void CalculateTruncatedMeanWithPercentageToDiscardGreaterThanOrEqualToFifty()
        {
            double[] numbers = { 1, 2, 3, 4, 5 };

            numbers.TruncatedMean(0.50);
        }

        [TestMethod]
        public void TestTruncatedMeanOfExample()
        {
            double[] numbers = { 1, 5, 6, 7, 8, 9, 10, 11, 12, 58 };
            const double percentageToTruncate = 0.1;

            double actualTruncatedMean = numbers.TruncatedMean(percentageToTruncate);
            const double expectedTruncatedMean = 8.5;

            Assert.AreEqual(expectedTruncatedMean, actualTruncatedMean, 0.0001);
        }
    }
}

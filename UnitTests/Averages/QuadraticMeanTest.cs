using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class QuadraticMeanTest
    {        
        [TestMethod]
        public void TestQuadraticMeanExample()
        {
            double[] numbers = { 1.0, 2.5, 4.0 };

            double quadraticMean = numbers.QuadraticMean();
            const double expectedMean = 2.783882181;

            Assert.AreEqual(expectedMean, quadraticMean, 0.0001);
        }

        [TestMethod]
        public void TestQuadraticMeanOfEmptyCollectionThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(
                CalculateQudraticMeanOfEmptyCollection);
        }

        private static void CalculateQudraticMeanOfEmptyCollection()
        {
            double[] numbers = { };

            numbers.QuadraticMean();
        }

        [TestMethod]
        public void TestQuadraticMeanOfNullCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(
                CalculateQudraticMeanOfNullCollection);
        }

        private static void CalculateQudraticMeanOfNullCollection()
        {
            double[] numbers = null;

            numbers.QuadraticMean();
        }
    }
}

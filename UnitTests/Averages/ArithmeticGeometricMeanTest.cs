using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class ArithmeticGeometricMeanTest
    {
        private readonly double _epsilon;

        public ArithmeticGeometricMeanTest()
        {
            _epsilon = 0.0001;
        }

        [TestMethod]
        public void TestAGMOf24and6()
        {
            const double x = 24;
            const double y = 6;

            double calculatedAgm = AverageExtensions.ArithmeticGeometricMean(x, y);
            const double expectedAgm = 13.45817148173;
            double differenceBetweenExpectedAndCalculatedValue = Math.Abs(expectedAgm - calculatedAgm);

            Assert.IsTrue(differenceBetweenExpectedAndCalculatedValue < _epsilon);
        }

        [TestMethod]
        public void TestAGMOfNegativeNumbersThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallAGMWithNegativeFirstArgument);
            ExceptionAssert.Throws<InvalidOperationException>(CallAGMWithNegativeSecondArgument);
        }

        private static void CallAGMWithNegativeFirstArgument()
        {
            AverageExtensions.ArithmeticGeometricMean(-1, 2);
        }

        private static void CallAGMWithNegativeSecondArgument()
        {
            AverageExtensions.ArithmeticGeometricMean(1, -2);
        }
    }
}

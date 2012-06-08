using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class GeometricMeanTest
    {
        private readonly double _epsilon;

        public GeometricMeanTest()
        {
            _epsilon = 0.0001;
        }

        [TestMethod]
        public void TestGeometricMeanOf3And30()
        {
            double[] numbers = { 3, 300 };

            double calculatedGeometricMean = numbers.GeometricMean();

            Assert.AreEqual(30, calculatedGeometricMean);
        }

        [TestMethod]
        public void TestGeometricMeanOfRange1To10()
        {
            IEnumerable<double> numbers =
                from number in Enumerable.Range(1, 10)
                select Convert.ToDouble(number);

            double calculatedValue = numbers.GeometricMean();
            const double expectedValue = 4.528728688;
            double differenceBetweenExpectedAndCalculatedValue = Math.Abs(expectedValue - calculatedValue);

            Assert.IsTrue(differenceBetweenExpectedAndCalculatedValue < _epsilon);
        }

        [TestMethod]
        public void TestGeometricMeanOfSingleNumberEqualsTheNumber()
        {
            // Use an arbitrary seed to achieve determinated behaviour
            Random random = new Random(1337);

            for (int i = 0; i < 50; i++)
            {
                double numberToTest = random.Next();
                double[] singleNumberCollection = { numberToTest };

                double calculatedGeometricMean = singleNumberCollection.GeometricMean();

                Assert.AreEqual(numberToTest, calculatedGeometricMean);
            }
        }

        [TestMethod]
        public void TestGeometricMeanOfNullCollectionThrowsNullArgumentException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(CallGeometricMeanWithNullCollection);
        }

        private static void CallGeometricMeanWithNullCollection()
        {
            double[] emptyNumbersArray = null;
            emptyNumbersArray.GeometricMean();
        }

        [TestMethod]
        public void TestGeometricMeanOfEmptyNumbersArrayThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallGeometicMeanWithEmptyNumbersArray);
        }

        private static void CallGeometicMeanWithEmptyNumbersArray()
        {
            double[] emptyNumbersArray = { };
            emptyNumbersArray.GeometricMean();
        }

        [TestMethod]
        public void TestGeometricMeanOfCollectionContainingNegativeNumbersThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallGeometicMeanWithNegativeNumbersCollection);
        }

        private static void CallGeometicMeanWithNegativeNumbersCollection()
        {
            double[] collectionContainingNegativeNumbers = { 1, 2, 3, -4, 5 };
            collectionContainingNegativeNumbers.GeometricMean();
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class HarmonicMeanTest
    {
        private readonly double _epsilon;

        public HarmonicMeanTest()
        {
            _epsilon = 0.0001;
        }

        [TestMethod]
        public void TestHarmonicMeanOf5And20()
        {
            double[] numbers = { 5, 20 };

            double calculatedHarmonicMean = numbers.HarmonicMean();
            const double expectedHarmonicMean = 8;

            Assert.AreEqual(expectedHarmonicMean, calculatedHarmonicMean);
        }

        [TestMethod]
        public void TestHarmoniMeanOfSingleNumberEqualsTheNumber()
        {
            // Use an arbitrary seed to achieve determinated behaviour
            Random random = new Random(1337);

            for (int i = 0; i < 50; i++)
            {
                double numberToTest = random.Next();
                double[] singleNumberCollection = { numberToTest };

                double calculatedHarmonicMean = singleNumberCollection.HarmonicMean();
                double differenBetweenExpectedAndCalculatedValue = Math.Abs(calculatedHarmonicMean - numberToTest);

                Assert.IsTrue(differenBetweenExpectedAndCalculatedValue < _epsilon);
            }
        }

        [TestMethod]
        public void TestHarmonicMeanOfCollectionContainingZeroValuesIsZero()
        {
            double[] numbers = { 1, 0, 5, 8, 0, 6 };

            const double expectedValue = 0;
            double calculatedValue = numbers.HarmonicMean();

            Assert.AreEqual(expectedValue, calculatedValue);
        }

        [TestMethod]
        public void TestHarmonicMeanOfNullCollectionThrowsNullArgumentException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(CallHarmonicMeanWithNullCollection);
        }

        private static void CallHarmonicMeanWithNullCollection()
        {
            double[] emptyNumbersArray = null;
            emptyNumbersArray.HarmonicMean();
        }

        [TestMethod]
        public void TestHarmonicMeanOfEmptyNumbersArrayThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallHarmonicMeanWithEmptyNumbersArray);
        }

        private static void CallHarmonicMeanWithEmptyNumbersArray()
        {
            double[] emptyNumbersArray = { };
            emptyNumbersArray.HarmonicMean();
        }

        [TestMethod]
        public void TestHarmonicMeanOfCollectionContainingNegativeNumbersThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallHarmonicMeanWithNegativeNumbersCollection);
        }

        private static void CallHarmonicMeanWithNegativeNumbersCollection()
        {
            double[] collectionContainingNegativeNumbers = { 1, 2, 3, -4, 5 };
            collectionContainingNegativeNumbers.HarmonicMean();
        }
    }
}
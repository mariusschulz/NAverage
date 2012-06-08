using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class MedianTest
    {
        [TestMethod]
        public void TestMedianOfSingleNumberEqualsTheNumber()
        {
            // Use an arbitrary seed to achieve determinated behaviour
            Random random = new Random(1337);

            for (int i = 0; i < 50; i++)
            {
                double numberToTest = random.Next();
                double[] singleNumberCollection = { numberToTest };

                double calculatedMedian = singleNumberCollection.Median();
                
                Assert.AreEqual(numberToTest, calculatedMedian);
            }
        }

        [TestMethod]
        public void TestMedianOfArrayWithAnEvenNumberOfElements()
        {
            double[] numbers = { 0, 5, 7, 7 };

            const double expectedValue = 6;
            double calculatedValue = numbers.Median();

            Assert.AreEqual(expectedValue, calculatedValue);
        }

        [TestMethod]
        public void TestMedianOfNullCollectionThrowsNullArgumentException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(CallMedianWithNullCollection);
        }

        private static void CallMedianWithNullCollection()
        {
            double[] emptyNumbersArray = null;
            emptyNumbersArray.Median();
        }

        [TestMethod]
        public void TestMedianOfEmptyNumbersArrayThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallMedianWithEmptyNumbersArray);
        }

        private static void CallMedianWithEmptyNumbersArray()
        {
            double[] emptyNumbersArray = { };
            emptyNumbersArray.Median();
        }
    }
}

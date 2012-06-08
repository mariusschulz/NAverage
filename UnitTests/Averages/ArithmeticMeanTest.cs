using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAverage;

namespace UnitTests.Averages
{
    [TestClass]
    public class ArithmeticMeanTest
    {
        [TestMethod]
        public void TestArithmeticMeanOfRange1To9()
        {
            double[] range1To9 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double calculatedArithmeticMean = range1To9.ArithmeticMean();

            Assert.AreEqual(5, calculatedArithmeticMean);
        }

        [TestMethod]
        public void TestArithmeticMeanOfRange0To100()
        {
            IEnumerable<double> range0To100 =
                from number in Enumerable.Range(0, 101)
                select Convert.ToDouble(number);

            double calculatedArithmeticMean = range0To100.ArithmeticMean();

            Assert.AreEqual(50, calculatedArithmeticMean);
        }

        [TestMethod]
        public void TestArithmeticMeanOfSingleNumberEqualsTheNumber()
        {
            // Use an arbitrary seed to achieve determinated behaviour
            Random random = new Random(1337);

            for (int i = 0; i < 50; i++)
            {
                double numberToTest = random.Next();
                double[] singleNumberCollection = { numberToTest };

                double calculatedArithmeticMean = singleNumberCollection.ArithmeticMean();

                Assert.AreEqual(numberToTest, calculatedArithmeticMean);
            }
        }

        [TestMethod]
        public void TestArithmeticMeanOfNullCollectionThrowsArgumentNullException()
        {
            ExceptionAssert.Throws<ArgumentNullException>(CallArithmeticMeanWithNullCollection);
        }

        private static void CallArithmeticMeanWithNullCollection()
        {
            double[] emptyNumbersArray = null;
            emptyNumbersArray.ArithmeticMean();
        }

        [TestMethod]
        public void TestArithmeticMeanOfEmptyNumbersArrayThrowsInvalidOperationException()
        {
            ExceptionAssert.Throws<InvalidOperationException>(CallArithmeticMeanWithEmptyNumbersArray);
        }

        private static void CallArithmeticMeanWithEmptyNumbersArray()
        {
            double[] emptyNumbersArray = { };
            emptyNumbersArray.ArithmeticMean();
        }
    }
}

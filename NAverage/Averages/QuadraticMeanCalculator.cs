using System;
using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the quadratic mean of a collection of numbers.
    /// </summary>
    internal class QuadraticMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the quadratic mean (or RMS, respectively) of the specified numbers.
        /// </summary>
        /// <param name="numbers">
        /// The numbers whose quadratic mean is to be calculated.
        /// </param>
        /// <returns>The quadratic mean of the specified collection of numbers.</returns>
        public static double QuadraticMean(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            IEnumerable<double> squaredNumbers = numbers.Select(n => n * n);

            double arithmeticMeanOfSquaredNumbers = squaredNumbers.ArithmeticMean();
            double quadraticMean = Math.Sqrt(arithmeticMeanOfSquaredNumbers);

            return quadraticMean;
        }
    }
}

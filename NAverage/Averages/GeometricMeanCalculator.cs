using System;
using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the geometric mean of a collection of numbers.
    /// </summary>
    internal class GeometricMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the geometric mean of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose geometric mean is to be calculated.</param>
        /// <returns>The geometric mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The collection must not contain negative numbers and must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        public static double GeometricMean(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            if (numbers.Any(number => number < 0))
            {
                throw CollectionContainingNegativeNumbersException;
            }

            double productOfNumbers = 1;

            foreach (double number in numbers)
            {
                productOfNumbers *= number;
            }

            double numbersCount = numbers.Count();
            double exponent = 1.0 / numbersCount;
            double geometricMean = Math.Pow(productOfNumbers, exponent);

            return geometricMean;
        }

        /// <summary>
        /// Calculates the geometric mean of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose geometric mean is to be calculated.</param>
        /// <returns>The geometric mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not contain negative numbers and must not be empty.
        /// </exception>
        public static double GeometricMean(params double[] numbers)
        {
            return GeometricMean(numbers as IEnumerable<double>);
        }
    }
}

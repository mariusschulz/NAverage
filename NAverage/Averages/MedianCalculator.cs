using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the median of a collection of numbers.
    /// </summary>
    internal class MedianCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the median of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose median is to be calculated.</param>
        /// <returns>The median of the given numbers.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not be empty.
        /// </exception>
        public static double Median(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            List<double> sortedNumbers = numbers.OrderBy(number => number).ToList();

            double median = 0;

            if (sortedNumbers.Count % 2 == 0)
            {
                double lowerMedian = sortedNumbers[sortedNumbers.Count / 2 - 1];
                double upperMedian = sortedNumbers[sortedNumbers.Count / 2];

                median = ArithmeticMeanCalculator.ArithmeticMean(lowerMedian, upperMedian);
            }
            else
            {
                median = sortedNumbers[sortedNumbers.Count / 2];
            }

            return median;
        }
    }
}

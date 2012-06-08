using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the harmonic mean of a collection of numbers.
    /// </summary>
    internal class HarmonicMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the harmonic mean of the given numbers.
        /// The harmonic mean is defined as zero if at least one of the numbers is zero.
        /// </summary>
        /// <param name="numbers">The numbers whose harmonic mean is to be calculated.</param>
        /// <returns>The harmonic mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not contain negative numbers and must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        public static double HarmonicMean(IEnumerable<double> numbers)
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

            if (numbers.Contains(0))
            {
                // If one of the values strives against zero the limiting value of the harmonic mean does, too.
                // Therefore, it is sensible to define the harmonic mean as being zero if at least one of the values is zero.
                return 0;
            }

            double sumOfReciprocalValues = numbers.Sum(number => 1.0 / number);
            double harmonicMean = numbers.Count() / sumOfReciprocalValues;

            return harmonicMean;
        }
    }
}

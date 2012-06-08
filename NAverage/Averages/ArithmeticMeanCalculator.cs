using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the arithmetic mean of a collection of numbers.
    /// </summary>
    internal class ArithmeticMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the arithmetic mean of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose arithmetic mean is to be calculated.</param>
        /// <returns>
        /// The arithmetic mean of the given numbers.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        public static double ArithmeticMean(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            // Use LINQ arithmetic mean calculation
            return numbers.Average();
        }

        /// <summary>
        /// Calculates the arithmetic mean of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose arithmetic mean is to be calculated.</param>
        /// <returns>
        /// The arithmetic mean of the given numbers.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not be empty.
        /// </exception>
        public static double ArithmeticMean(params double[] numbers)
        {
            return ArithmeticMean(numbers as IEnumerable<double>);
        }
    }
}

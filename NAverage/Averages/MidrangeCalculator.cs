using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the midrange of a collection of numbers.
    /// </summary>
    internal class MidrangeCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the midrange of the specified collection of numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose midrange is to be calculated.</param>
        /// <returns>
        /// The midrange of the specified collection of numbers.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not be empty.
        /// </exception>
        public static double Midrange(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            double minValue = numbers.Min();
            double maxValue = numbers.Max();

            double midrange = ArithmeticMeanCalculator.ArithmeticMean(minValue, maxValue);

            return midrange;
        }
    }
}

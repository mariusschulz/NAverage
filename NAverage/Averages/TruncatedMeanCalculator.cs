using System;
using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the truncated mean of a specified collection
    /// of numbers and a given percentage of numbers that are to be truncated.
    /// </summary>
    internal class TruncatedMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the truncated mean of the specified collection of numbers
        /// regarding the specified percentage of elements to be discarded.
        /// </summary>
        /// <param name="numbers">The numbers whose truncated mean is to be calculated.</param>
        /// <param name="percentageToDiscard">The percentage of elements that
        /// are to be discarded at both sides of the collection in each case.</param>
        /// <returns>The truncated mean of the specified collection of numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        public static double TruncatedMean(IEnumerable<double> numbers,
            double percentageToDiscard)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            // The percentage to discard needs to be greater than 0 and smaller than 50% as
            // it makes no sense to both discard nothing and discard all (50% on both sides).
            if (percentageToDiscard <= 0 ||
                percentageToDiscard >= 0.5)
            {
                throw new ArgumentException(
                    "percentageToDiscard must be greater than 0 and smaller than 0.5!");
            }

            var orderedNumbers = numbers.OrderBy(n => n);

            IEnumerable<double> truncatedNumbers =
                TruncationHelper<double>.Truncate(orderedNumbers, percentageToDiscard);

            double truncatedMean = truncatedNumbers.ArithmeticMean();

            return truncatedMean;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the winsorized mean of a specified collection
    /// of numbers regarding the specified percentage of elements to be replaced.
    /// </summary>
    internal class WinsorizedMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the winsorized mean of the specified collection of numbers
        /// regarding the specified percentage of elements to be replaced.
        /// </summary>
        /// <param name="numbers">The numbers whose winsorized mean is to be calculated.</param>
        /// <param name="percentageToReplace">The percentage to replace.</param>
        /// <returns>
        /// The winsorized mean of the specified collection of numbers.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified percentage to replace must be greater than zero and smaller than 0.5.
        /// </exception>
        public static double WinsorizedMean(IEnumerable<double> numbers,
            double percentageToReplace)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            // The percentage to replace needs to be greater than 0 and smaller than 50% as
            // it makes no sense to both replace nothing and replace all (50% on both sides).
            if (percentageToReplace <= 0 ||
                percentageToReplace >= 0.5)
            {
                throw new ArgumentException(
                    "percentageToReplace must be greater than 0 and smaller than 0.5!");
            }

            var orderedNumbers = numbers.OrderBy(n => n);

            List<double> truncatedNumbers =
                TruncationHelper<double>.Truncate(orderedNumbers, percentageToReplace)
                .ToList();            

            int numberOfElements = numbers.Count();
            int elementsToReplace = (int)Math.Floor(numberOfElements * percentageToReplace);

            double minValue = truncatedNumbers.Min();
            double maxValue = truncatedNumbers.Max();

            for (int i = 0; i < elementsToReplace; i++)
            {
                truncatedNumbers.Insert(0, minValue);
                truncatedNumbers.Add(maxValue);                
            }

            double winsorizedMean = truncatedNumbers.ArithmeticMean();

            return winsorizedMean;
        }
    }
}

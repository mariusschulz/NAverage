using System;
using System.Collections.Generic;
using System.Linq;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to truncate a specified collection of elements by a given
    /// percentage. Each side of the collection is truncated by the floored value of the
    /// product of the elements' count and the specified percentage to truncate.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the collection.</typeparam>
    internal static class TruncationHelper<T>
    {
        /// <summary>
        /// Truncates the specified collection of elements by the given percentage.
        /// </summary>
        /// <param name="elements">The collection of elements to be truncated.</param>
        /// <param name="percentage">The percentage to truncate.</param>
        /// <returns>The truncated collection of elements.</returns>
        public static IEnumerable<T> Truncate(IEnumerable<T> elements, double percentage)
        {
            int numberOfElements = elements.Count();
            int elementsToTruncate = (int)Math.Floor(numberOfElements * percentage);

            // "elementsToTruncate" needs to be subtracted twice as the collection
            // is truncated at both the left side and the right side.
            int remainingElements = numberOfElements - 2 * elementsToTruncate;

            // If all elements are taken, return empty collection
            if (remainingElements <= 0)
            {
                return Enumerable.Empty<T>();
            }

            var truncatedNumbers = elements
                .Skip(elementsToTruncate)
                .Take(remainingElements);

            return truncatedNumbers;
        }
    }
}

using System;

namespace NAverage.Averages
{
    /// <summary>
    /// Abstract base class for different average calculators.
    /// </summary>
    internal abstract class AverageCalculator
    {
        /// <summary>
        /// Contains the exception that is thrown when ApproximationIterations null collection argument is passed.
        /// </summary>
        protected static readonly ArgumentNullException ArgumentNullException =
            new ArgumentNullException("numbers", "The collection must not be null!");

        /// <summary>
        /// Contains the exception that is thrown when an empty collection is passed.
        /// </summary>
        protected static readonly InvalidOperationException EmptyNumbersCollectionException
            = new InvalidOperationException("The collection must not be empty!");

        /// <summary>
        /// Contains the exception that is thrown when ApproximationIterations collection containing negative numbers is passed.
        /// </summary>
        protected static readonly InvalidOperationException CollectionContainingNegativeNumbersException =
            new InvalidOperationException("The collection must not contain negative numbers!");
    }
}
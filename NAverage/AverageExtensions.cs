using System.Collections.Generic;
using NAverage.Averages;

namespace NAverage
{
    /// <summary>
    /// Provides extended average calculation extension methods.
    /// </summary>
    public static class AverageExtensions
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
        public static double ArithmeticMean(this IEnumerable<double> numbers)
        {
            return ArithmeticMeanCalculator.ArithmeticMean(numbers);
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
        public static double GeometricMean(this IEnumerable<double> numbers)
        {
            return GeometricMeanCalculator.GeometricMean(numbers);
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

        /// <summary>
        /// Calculates the arithmetic-geometric mean of the specified two numbers.
        /// </summary>
        /// <param name="x">The first number.</param>
        /// <param name="y">The second number.</param>
        /// <returns>
        /// The arithmetic-geometric mean of the specified two numbers.
        /// </returns>
        public static double ArithmeticGeometricMean(double x, double y)
        {
            return ArithmeticGeometricMeanCalculator.ArithmeticGeometricMean(x, y);
        }

        /// <summary>
        /// Calculates the harmonic mean of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose harmonic mean is to be calculated.</param>
        /// <returns>The harmonic mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not contain negative numbers and must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        public static double HarmonicMean(this IEnumerable<double> numbers)
        {
            return HarmonicMeanCalculator.HarmonicMean(numbers);
        }

        /// <summary>
        /// Calculates the harmonic mean of the given numbers.
        /// The harmonic mean is defined as zero if at least one of the numbers is zero.
        /// </summary>
        /// <param name="numbers">The numbers whose harmonic mean is to be calculated.</param>
        /// <returns>The harmonic mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not contain negative numbers and must not be empty.
        /// </exception>
        public static double HarmonicMean(params double[] numbers)
        {
            return HarmonicMean(numbers as IEnumerable<double>);
        }

        /// <summary>
        /// Calculates the quadratic mean (or RMS, respectively) of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose quadratic mean is to be calculated.</param>
        /// <returns>The quadratic mean of the given numbers.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// The specified numbers collection must not be empty.
        /// </exception>
        public static double QuadraticMean(this IEnumerable<double> numbers)
        {
            return QuadraticMeanCalculator.QuadraticMean(numbers);
        }

        /// <summary>
        /// Calculates the quadratic mean (or RMS, respectively) of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose quadratic mean is to be calculated.</param>
        /// <returns>The quadratic mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not be empty.
        /// </exception>
        public static double QuadraticMean(params double[] numbers)
        {
            return QuadraticMean(numbers as IEnumerable<double>);
        }

        /// <summary>
        /// Calculates the truncated mean of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose truncated mean is to be calculated.</param>
        /// <param name="percentageToTruncate">The percentage to truncate.</param>
        /// <returns>The truncated mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not be empty.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The specified collection must not be null.
        /// </exception>
        public static double TruncatedMean(this IEnumerable<double> numbers,
            double percentageToTruncate)
        {
            return TruncatedMeanCalculator.TruncatedMean(numbers, percentageToTruncate);
        }

        /// <summary>
        /// Calculates the truncated mean of the given numbers.
        /// </summary>
        /// <param name="percentageToTruncate">The percentage to truncate.</param>
        /// <param name="numbers">The numbers whose truncated mean is to be calculated.</param>
        /// <returns>The truncated mean of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not be empty.
        /// </exception>
        public static double TruncatedMean(double percentageToTruncate, params double[] numbers)
        {
            return TruncatedMean(numbers as IEnumerable<double>, percentageToTruncate);
        }

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
        public static double WinsorizedMean(this IEnumerable<double> numbers,
            double percentageToReplace)
        {
            return WinsorizedMeanCalculator.WinsorizedMean(numbers, percentageToReplace);
        }

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
        public static double WinsorizedMean(double percentageToReplace, params double[] numbers)
        {
            return WinsorizedMean(numbers as IEnumerable<double>, percentageToReplace);
        }

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
        public static double Median(this IEnumerable<double> numbers)
        {
            return MedianCalculator.Median(numbers);
        }

        /// <summary>
        /// Calculates the median of the given numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose median is to be calculated.</param>
        /// <returns>The median of the given numbers.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// The arguments must not be empty.
        /// </exception>
        public static double Median(params double[] numbers)
        {
            return Median(numbers as IEnumerable<double>);
        }

        /// <summary>
        /// Calculates the modes of the specified integer values.
        /// </summary>
        /// <param name="numbers">The collection whose modes are to be calculated.</param>
        /// <returns>The modes of the specified collection.</returns>
        public static int[] Modes(this IEnumerable<int> numbers)
        {
            return ModesCalculator.Modes(numbers);
        }

        /// <summary>
        /// Calculates the modes of the specified integer values.
        /// </summary>
        /// <param name="numbers">The integers whose modes are to be calculated.</param>
        /// <returns>The modes of the specified collection.</returns>
        public static int[] Modes(params int[] numbers)
        {
            return Modes(numbers as IEnumerable<int>);
        }

        /// <summary>
        /// Calculates the modes of the specified collection of numbers using the specified discretization unit epsilon.
        /// </summary>
        /// <param name="numbers">The collection whose modes are to be calculated.</param>
        /// <param name="discretizationEpsilon">Discretization unit epsilon.</param>
        /// <returns>The modes of the specified collection.</returns>
        public static double[] Modes(this IEnumerable<double> numbers, double discretizationEpsilon)
        {
            return ModesCalculator.Modes(numbers, discretizationEpsilon);
        }

        /// <summary>
        /// Calculates the modes of the specified numbers using the specified discretization unit epsilon.
        /// </summary>
        /// <param name="discretizationEpsilon">Discretization unit epsilon.</param>
        /// <param name="numbers">The numbers whose modes are to be calculated.</param>
        /// <returns>The modes of the specified collection.</returns>
        public static double[] Modes(double discretizationEpsilon, params double[] numbers)
        {
            return Modes(numbers as IEnumerable<double>, discretizationEpsilon);
        }

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
        public static double Midrange(this IEnumerable<double> numbers)
        {
            return MidrangeCalculator.Midrange(numbers);
        }

        /// <summary>
        /// Calculates the midrange of the specified collection of numbers.
        /// </summary>
        /// <param name="numbers">The numbers whose midrange is to be calculated.</param>
        /// <returns>
        /// The midrange of the specified collection of numbers.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The specified collection must not be empty.
        /// </exception>
        public static double Midrange(params double[] numbers)
        {
            return Midrange(numbers as IEnumerable<double>);
        }
    }
}

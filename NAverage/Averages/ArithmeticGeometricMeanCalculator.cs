using System;

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the arithmetic-geometric mean of two given numbers.
    /// </summary>
    internal class ArithmeticGeometricMeanCalculator : AverageCalculator
    {
        /// <summary>
        /// Stores the number of iterations used to approximate the arithmetic-geometric mean.
        /// </summary>
        private const int ApproximationIterations = 50;

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
            if (x < 0 || y < 0)
            {
                throw new InvalidOperationException("Both arguments must be non-negative!");
            }

            double a_n = 0;
            double g_n = 0;

            for (int n = 0; n < ApproximationIterations; n++)
            {
                a_n = ArithmeticMeanCalculator.ArithmeticMean(x, y);
                g_n = GeometricMeanCalculator.GeometricMean(x, y);

                x = a_n;
                y = g_n;
            }

            return a_n;
        }
    }
}

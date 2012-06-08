using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Thanks to zommi from myCSharp.de who provided the code of the algorithm below!
 */

namespace NAverage.Averages
{
    /// <summary>
    /// Provides functionality to calculate the modes of a collection of numbers.
    /// </summary>
    internal class ModesCalculator : AverageCalculator
    {
        /// <summary>
        /// Calculates the modes of a collection of numbers using the specified discretization unit epsilon.
        /// </summary>
        /// <param name="numbers">The collection whose modes are to be calculated.</param>
        /// <param name="discretizationEpsilon">Discretization unit epsilon.</param>
        /// <returns>
        /// An array containing the arithmetic mean of all intervals
        /// (that are at most one epsilon wide) with the most occurences.
        /// </returns>
        public static double[] Modes(IEnumerable<double> numbers, double discretizationEpsilon)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }
            
            LinkedList<Interval> bestIntervals = new LinkedList<Interval>();
            int maxCount = 0;

            // Sort numbers
            IOrderedEnumerable<double> sorted = numbers.OrderBy(x => x);

            // Iterate over all maximum-sized intervals
            foreach (Interval interval in IntervalHelper.Intervals(sorted, discretizationEpsilon))
            {
                // If new maximum found, delete all maximums until now
                if (interval.ElementsInside > maxCount)
                {
                    maxCount = interval.ElementsInside;
                    bestIntervals.Clear();
                }

                // Save this interval as a maximum one if necessary
                if (interval.ElementsInside == maxCount)
                {
                    bestIntervals.AddLast(interval);
                }
            }

            // Return the arithmetic mean of the mid points
            return bestIntervals
                    .Select(x => x.MidPoint)
                    .ToArray();
        }

        /// <summary>
        /// Calculates the modes of a collection of integer values.
        /// </summary>
        /// <param name="numbers">The collection whose modesare to be calculated.</param>
        /// <returns>
        /// An array containing the arithmetic mean of all intervals
        /// (that are at most one epsilon wide) with the most occurences.
        /// </returns>
        public static int[] Modes(IEnumerable<int> numbers)
        {
            if (numbers == null)
            {
                throw ArgumentNullException;
            }

            if (!numbers.Any())
            {
                throw EmptyNumbersCollectionException;
            }

            IEnumerable<double> doubleNumbers =
                from number in numbers
                select Convert.ToDouble(number);

            double[] doubleModes = Modes(doubleNumbers, 0);

            return doubleModes.Select(
                   number => Convert.ToInt32(Math.Round(number))
                   ).ToArray();
        }

        internal static class IntervalHelper
        {
            /// <summary>
            /// Iterates over all maximum intervals from the 
            /// collection that are lower than or equal to epsilon.
            /// </summary>
            /// <param name="sortedNumbers">Sorted collection whose
            /// modes are to be calculated.</param>
            /// <param name="epsilon">Maximum size of the intervals.</param>
            /// <returns></returns>
            internal static IEnumerable<Interval> Intervals(
                IEnumerable<double> sortedNumbers,double epsilon)
            {
                SlidingWindow window = new SlidingWindow(sortedNumbers);

                window.MoveStart();
                window.MoveEnd();

                // No element contained?
                if (window.EndReached)
                    yield break;

                Interval lastInterval = window.Interval;

                // While the end is not reached ...
                while (!window.EndReached)
                {
                    // Move upper end as long as possible
                    while (!window.EndReached && window.Width <= epsilon)
                    {
                        // Save the last interval anyway
                        lastInterval = window.Interval;
                        window.MoveEnd();
                    }

                    // Return the last interval smaller than or equal to epsilon
                    yield return lastInterval;

                    // Move lower bounds until we reach epsilon again
                    while (!window.EndReached && window.Width > epsilon)
                    {
                        window.MoveStart();
                    }
                }
            }
        }

        /// <summary>
        /// Represents an interval used by the discretization algorithm.
        /// </summary>
        internal struct Interval
        {
            /// <summary>
            /// The lower value of the interval.
            /// </summary>
            public double Start;
            
            /// <summary>
            /// The upper value of the interval.
            /// </summary>
            public double End;

            /// <summary>
            /// The number of elements inside.
            /// </summary>
            public int ElementsInside;

            /// <summary>
            /// Gets the mid point (arithmetic mean) of this interval.
            /// </summary>
            /// <value>The mid point.</value>
            public double MidPoint
            {
                get
                {
                    return ArithmeticMeanCalculator.ArithmeticMean(Start, End);
                }
            }

            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return String.Format("[{0} : {1}]({2})", Start, End, ElementsInside);
            }
        }

        /// <summary>
        /// Represents a window gliding over the collection.
        /// </summary>
        internal class SlidingWindow
        {
            public bool EndReached { get; private set; }
            public int ElementsInside { get; private set; }

            public double Start { get { return _startEnumerator.Current; } }
            public double End { get { return _endEnumerator.Current; } }
            public double Width { get { return End - Start; } }

            private readonly IEnumerator<double> _startEnumerator;
            private readonly IEnumerator<double> _endEnumerator;

            /// <summary>
            /// Initializes a new instance of the <see cref="SlidingWindow"/> class.
            /// </summary>
            /// <param name="collection">The collection.</param>
            public SlidingWindow(IEnumerable<double> collection)
            {
                _startEnumerator = collection.GetEnumerator();
                _endEnumerator = collection.GetEnumerator();
                ElementsInside = 1;
                EndReached = false;
            }

            public Interval Interval
            {
                get
                {
                    return new Interval
                    {
                        Start = Start,
                        End = End,
                        ElementsInside = ElementsInside
                    };
                }
            }

            /// <summary>
            /// Moves the window's start.
            /// </summary>
            public void MoveStart()
            {
                ElementsInside--;
                EndReached |= !_startEnumerator.MoveNext();
            }

            /// <summary>
            /// Moves the window's end.
            /// </summary>
            public void MoveEnd()
            {
                ElementsInside++;
                EndReached |= !_endEnumerator.MoveNext();
            }
        }
    }
}

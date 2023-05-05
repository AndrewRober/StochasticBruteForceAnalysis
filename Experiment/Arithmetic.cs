namespace Experiment
{
    /// <summary>
    /// This class provides static methods for various arithmetic operations and statistical calculations.
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// Calculates the median value of an IEnumerable of integers.
        /// </summary>
        /// <param name="source">Source collection of integers.</param>
        /// <returns>Median value of the input collection.</returns>
        public static double Median(this IEnumerable<int> source)
        {
            int count = source.Count();
            if (count == 0)
                throw new InvalidOperationException("Empty collection");

            int middleIndex = count / 2;
            var sorted = source.OrderBy(value => value);
            return count % 2 == 0 ? (sorted.ElementAt(middleIndex - 1) +
                sorted.ElementAt(middleIndex)) / 2.0 : sorted.ElementAt(middleIndex);
        }

        /// <summary>
        /// Calculates the mode value of an integer array.
        /// </summary>
        /// <param name="source">Source array of integers.</param>
        /// <returns>Mode value of the input array.</returns>
        public static double Mode(this int[] source)
        {
            int modeCount = 0, currentCount = 1, mode = 0;
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] == source[i - 1])
                    currentCount++;
                else
                {
                    if (currentCount > modeCount)
                    {
                        modeCount = currentCount;
                        mode = source[i - 1];
                    }
                    currentCount = 1;
                }
            }
            if (currentCount > modeCount)
            {
                modeCount = currentCount;
                mode = source[source.Length - 1];
            }
            return mode;
        }

        /// <summary>
        /// Calculates the first (Q1), second (Q2), and third (Q3) quartiles of a sorted integer array.
        /// </summary>
        /// <param name="sortedData">Sorted array of integers.</param>
        /// <returns>A tuple containing the first (Q1), second (Q2), and third (Q3) quartiles.</returns>
        public static (double Q1, double Q2, double Q3) CalculateQuartiles(int[] sortedData)
        {
            if (sortedData.Length == 0)
                throw new ArgumentException("Data must contain at least one element");

            return sortedData.Length % 2 == 0
                ? ((double Q1, double Q2, double Q3))(CalculateQuartile(sortedData.Take(sortedData.Length / 2).ToArray()),
                    CalculateQuartile(sortedData), CalculateQuartile(sortedData.TakeLast(sortedData.Length / 2).ToArray()))
                : ((double Q1, double Q2, double Q3))(CalculateQuartile(sortedData.Take((sortedData.Length - 1) / 2).ToArray()),
                    CalculateQuartile(sortedData), CalculateQuartile(sortedData.TakeLast((sortedData.Length - 1) / 2).ToArray()));
        }

        /// <summary>
        /// Calculates a single quartile of a sorted integer array.
        /// </summary>
        /// <param name="sortedData">Sorted array of integers.</param>
        /// <returns>The calculated quartile value.</returns>
        public static double CalculateQuartile(int[] sortedData)
        {
            if (sortedData.Length == 0)
                throw new ArgumentException("Data must contain at least one element");

            int mid = sortedData.Length / 2;
            return sortedData.Length % 2 == 0 ? (sortedData[mid - 1] + sortedData[mid]) / 2.0 : sortedData[mid];
        }

        /// <summary>
        /// Calculates the standard deviation of an integer array with and without bias correction.
        /// </summary>
        /// <param name="data">Array of integers.</param>
        /// <returns>A tuple containing the standard deviations without and with bias correction.</returns>
        public static (double withoutBias, double withBias) StandardDeviationBiases(int[] data)
        {
            double sumOfSquaredDeviations = data.AsParallel().Sum(value => Math.Pow(value - (data.Sum() / data.Length), 2));
            return (Math.Sqrt(sumOfSquaredDeviations / (data.Length - 1)),
                Math.Sqrt(sumOfSquaredDeviations / (data.Length)));
        }

        /// <summary>
        /// Calculates the standard deviation of an integer array.
        /// </summary>
        /// <param name="data">Array of integers.</param>
        /// <returns>Standard deviation of the input array.</returns>
        public static double StandardDeviation(int[] data) => Math.Sqrt(Variance(data));

        /// <summary>
        /// Calculates the variance of an integer array.
        /// </summary>
        /// <param name="data">Array of integers.</param>
        /// <returns>Variance of the input array.</returns>
        public static double Variance(int[] data) =>
            data.AsParallel().Sum(value => Math.Pow(value - (data.Sum() / data.Length), 2)) / (data.Length);

        /// <summary>
        /// Calculates the variance of an integer array without bias correction.
        /// </summary>
        /// <param name="data">Array of integers.</param>
        /// <returns>Variance of the input array without bias correction.</returns>
        public static double VarianceWithoutBias(int[] data) =>
            data.AsParallel().Sum(value => Math.Pow(value - (data.Sum() / data.Length), 2)) / (data.Length - 1);

        /// <summary>
        /// Calculates various statistical measures for an integer array, including mean, median, mode, min, max, range, IQR, Q1, Q2, and Q3.
        /// </summary>
        /// <param name="data">Array of integers.</param>
        /// <returns>A tuple containing mean, median, mode, min, max, range, IQR, Q1, Q2, and Q3.</returns>
        public static (double mean, double median, double mode, int min, int max, double range,
            double IQR, double Q1, double Q2, double Q3)
            CalculateStatistics(int[] data)
        {

            int[] sortedData = data.OrderBy(value => value).ToArray();

            var Quartiles = CalculateQuartiles(sortedData);

            return (data.Average(), data.Median(), sortedData.Mode(), data.Min(), data.Max(),
                sortedData[sortedData.Length - 1] - sortedData[0],
                Quartiles.Q3 - Quartiles.Q1, Quartiles.Q1, Quartiles.Q2, Quartiles.Q3);
        }
    }
}
namespace Experiment
{
    /// <summary>
    /// This class provides helper methods for generating integer sets and shuffling collections.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Random number generator.
        /// </summary>
        static Random RND = new Random();

        /// <summary>
        /// Generates a sequential set of integers from 0 to count - 1.
        /// </summary>
        /// <param name="count">Number of integers in the set.</param>
        /// <returns>An array of sequential integers.</returns>
        public static int[] GenerateSequentialSet(int count) => Enumerable.Range(0, count).ToArray();

        /// <summary>
        /// Generates a random set of integers of the specified count.
        /// </summary>
        /// <param name="count">Number of integers in the set.</param>
        /// <returns>An array of randomly ordered integers.</returns>
        public static int[] GenerateRandomSet(int count) => GenerateSequentialSet(count).ShuffleIterator(RND).ToArray();

        /// <summary>
        /// Generates a partitioned set of integers of the specified count and splitCount, with optional randomization of range.
        /// </summary>
        /// <param name="count">Number of integers in the set.</param>
        /// <param name="splitCount">Number of partitions to divide the set into.</param>
        /// <param name="randomizeRange">Whether to randomize the ranges within partitions.</param>
        /// <returns>An array of partitioned integers with optional randomization of range.</returns>
        public static int[] GeneratePartitionedRandomRangesSet(int count, int splitCount, bool randomizeRange)
        {
            var initialSet = GenerateSequentialSet(count);
            var splitSize = count / splitCount;

            if(initialSet.Length % splitCount != 0)
                throw new ArgumentException("Count must be divisible by splitCount");

            var rangesIndexes = GenerateSequentialSet(splitCount)
                .ShuffleIterator(RND)
                .Select(i => i * splitSize).ToArray();

            var result = new int[count];

            for (int i = 0; i < rangesIndexes.Length; i++)
            {
                int rangeIndex = rangesIndexes[i];
                int[] range = initialSet.Skip(rangeIndex).Take(splitSize).ToArray();
                int[] rangeRandom = randomizeRange ?
                    range.ShuffleIterator(RND).ToArray() : range;
                Array.Copy(rangeRandom, 0, result, i * splitSize, splitSize);
            }

            return result;
        }

        /// <summary>
        /// Shuffles the source collection using the Fisher-Yates shuffle algorithm.
        /// </summary>
        /// <typeparam name="T">Type of elements in the source collection.</typeparam>
        /// <param name="source">Source collection to be shuffled.</param>
        /// <param name="rng">Random number generator.</param>
        /// <returns>A shuffled collection.</returns>
        public static IEnumerable<T> ShuffleIterator<T>(
        this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        /// <summary>
        /// Helper class for formatting TimeSpan objects as strings.
        /// </summary>
        public static class TimeFormatter
        {

            /// <summary>
            /// Formats a TimeSpan object as a string in the format "h:mm:ss.fff".
            /// </summary>
            /// <param name="timeSpan">The TimeSpan object to be formatted.</param>
            /// <returns>A formatted string representing the TimeSpan object.</returns>
            public static string FormatTime(TimeSpan timeSpan)
            {
                string output = "";
                if (timeSpan.Hours > 0)
                    output += timeSpan.Hours + "h ";
                if (timeSpan.Minutes > 0)
                    output += timeSpan.Minutes + "m ";
                output += timeSpan.Seconds + "s";
                return output;
            }
        }
    }
}
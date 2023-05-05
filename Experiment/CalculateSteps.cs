namespace Experiment
{
    /// <summary>
    /// This class provides methods to calculate different types of sequential steps.
    /// </summary>
    public static class CalculateSteps
    {
        /// <summary>
        /// Random number generator.
        /// </summary>
        static Random RND = new Random();

        /// <summary>
        /// Returns a tuple containing the results of the four different calculation methods.
        /// </summary>
        /// <param name="setSize">Size of the set of integers to perform calculations on.</param>
        /// <param name="splitCount">Number of partitions to divide the set into for partitioned methods.</param>
        /// <returns>A tuple containing the results of the four calculation methods.</returns>
        public static  (int M1, int M2, int M3, int M4) CalculateSequentialSteps(int setSize, int splitCount) =>
            (CalculateSequentialSteps(setSize),
                       CalculateStochasticSteps(setSize),
                       CalculatePartitionedSteps(setSize, splitCount),
                       CalculateRandomPartitionedSteps(setSize, splitCount));

        /// <summary>
        /// Returns a random number between 1 and setSize.
        /// </summary>
        /// <param name="setSize">Size of the set of integers.</param>
        /// <returns>A random integer between 1 and setSize (inclusive).</returns>
        public static int CalculateSequentialSteps(int setSize) => RND.Next(setSize) + 1;

        /// <summary>
        /// Returns the index of a random number within a random set of integers of size 'setSize'.
        /// </summary>
        /// <param name="setSize">Size of the set of integers.</param>
        /// <returns>The index of a random number within a random set.</returns>
        public static int CalculateStochasticSteps(int setSize) =>
            Array.IndexOf(Helpers.GenerateRandomSet(setSize), RND.Next(setSize)) + 1;

        /// <summary>
        /// Returns the index of a random number within a partitioned set of integers of size 'setSize'.
        /// </summary>
        /// <param name="setSize">Size of the set of integers.</param>
        /// <param name="splitCount">Number of partitions to divide the set into.</param>
        /// <returns>The index of a random number within a partitioned set.</returns>
        public static int CalculatePartitionedSteps(int setSize, int splitCount) =>
            Array.IndexOf(Helpers.GeneratePartitionedRandomRangesSet(setSize, splitCount, false), RND.Next(setSize)) + 1;

        /// <summary>
        /// Returns the index of a random number within a partitioned set of integers of size 'setSize' with randomized ranges.
        /// </summary>
        /// <param name="setSize">Size of the set of integers.</param>
        /// <param name="splitCount">Number of partitions to divide the set into.</param>
        /// <returns>The index of a random number within a partitioned set with randomized ranges.</returns>
        public static int CalculateRandomPartitionedSteps(int setSize, int splitCount) =>
            Array.IndexOf(Helpers.GeneratePartitionedRandomRangesSet(setSize, splitCount, true), RND.Next(setSize)) + 1;
    }
}
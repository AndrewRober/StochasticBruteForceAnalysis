using System.Diagnostics;
using System.Text;

namespace Experiment
{
    internal class Program
    {
        /// <summary>
        /// Constants defining the number of trials, set sizes, and split count used in the experiment.
        /// </summary>
        const int TRAILCOUNT = 1_000_000, SETSIZE1 = 1000, SETSIZE2 = 1_000_00, SPLITCOUNT = 10;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Call the exp() method with different set sizes
            exp(SETSIZE1);
            exp(SETSIZE2);
        }

        /// <summary>
        /// Executes the experiment for a given set size.
        /// The experiment calculates sequential steps using the CalculateSteps class,
        /// collects the results, and saves them to CSV files.
        /// </summary>
        /// <param name="setsize">The size of the set for which the experiment will be run.</param>
        static void exp(int setsize)
        {
            // Initialize the Stopwatch and StringBuilder
            var sw = new Stopwatch();
            sw.Start();
            var sb = new StringBuilder();

            // Write the header row for the CSV file
            sb.AppendLine($"M1,M2,M3,M4");

            // Initialize arrays to store the results
            int[] M1 = new int[TRAILCOUNT], M2 = new int[TRAILCOUNT], M3 = new int[TRAILCOUNT], M4 = new int[TRAILCOUNT];

            // Run the experiment TRAILCOUNT times
            for (int i = 0; i < TRAILCOUNT; i++)
            {
                // Calculate the steps and store the results
                var result = CalculateSteps.CalculateSequentialSteps(setsize, SPLITCOUNT);
                sb.AppendLine($"{result.M1}, {result.M2}, {result.M3}, {result.M4}");
                M1[i] = result.M1; M2[i] = result.M2; M3[i] = result.M3; M4[i] = result.M4;

                // Update the console title with progress and estimated time remaining
                if ((i % 1000 == 0 && i > 0) || i == TRAILCOUNT)
                {
                    TimeSpan timeElapsed = sw.Elapsed;
                    double percentComplete = (double)i / TRAILCOUNT;
                    TimeSpan estimatedTimeRemaining = TimeSpan.FromMilliseconds((sw.ElapsedMilliseconds / percentComplete) - sw.ElapsedMilliseconds);
                    string remaining = Helpers.TimeFormatter.FormatTime(estimatedTimeRemaining);
                    Console.Title = $"exp {setsize}: {i}/{TRAILCOUNT} {percentComplete * 100:f2}% complete. Estimated time remaining: {remaining}";
                }
            }

            // Write the results to a file
            File.WriteAllText($"results_{setsize}.txt", sb.ToString());

            // Calculate the statistics for each array
            var M1Statistics = Arithmetic.CalculateStatistics(M1);
            var M2Statistics = Arithmetic.CalculateStatistics(M2);
            var M3Statistics = Arithmetic.CalculateStatistics(M3);
            var M4Statistics = Arithmetic.CalculateStatistics(M4);

            // Build a new StringBuilder for the statistics
            sb = new StringBuilder();

            // Write the header row for the statistics CSV file
            sb.AppendLine("M,Mean,Median,Mode,Min,Max,Range,IQR,Q1,Q2,Q3");

            // Write the statistics for each array
            sb.AppendLine($"M1,{M1Statistics.mean},{M1Statistics.median},{M1Statistics.mode},{M1Statistics.min},{M1Statistics.max},{M1Statistics.range},{M1Statistics.IQR},{M1Statistics.Q1},{M1Statistics.Q2},{M1Statistics.Q3}");
            sb.AppendLine($"M2,{M2Statistics.mean},{M2Statistics.median},{M2Statistics.mode},{M2Statistics.min},{M2Statistics.max},{M2Statistics.range},{M2Statistics.IQR},{M2Statistics.Q1},{M2Statistics.Q2},{M2Statistics.Q3}");
            sb.AppendLine($"M3,{M3Statistics.mean},{M3Statistics.median},{M3Statistics.mode},{M3Statistics.min},{M3Statistics.max},{M3Statistics.range},{M3Statistics.IQR},{M3Statistics.Q1},{M3Statistics.Q2},{M3Statistics.Q3}");
            sb.AppendLine($"M4,{M4Statistics.mean},{M4Statistics.median},{M4Statistics.mode},{M4Statistics.min},{M4Statistics.max},{M4Statistics.range},{M4Statistics.IQR},{M4Statistics.Q1},{M4Statistics.Q2},{M4Statistics.Q3}");

            // Write the statistics to a file
            File.WriteAllText($"statistics_{setsize}.txt", sb.ToString());
        }
    }
}
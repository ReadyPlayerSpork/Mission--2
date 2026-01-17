// LUKE MILLER
// IS 413 - MISSION 2
// SECTION 2 GROUP 15

namespace Mission_2;

/// <summary>
/// This class is responsible for simulating dice rolls.
/// It contains a method that simulates rolling two 6-sided dice multiple times
/// and returns an array tracking how many times each sum (2-12) was rolled.
/// </summary>
public class DiceRoller
{
    // Random number generator used to simulate dice rolls
    // This is a field (class-level variable) that will be used by the SimulateRolls method
    private Random random = new Random();

    /// <summary>
    /// Simulates rolling two 6-sided dice a specified number of times.
    /// Each roll generates two random numbers (1-6) and adds them together.
    /// The results are stored in an array where the index represents the sum (2-12).
    /// </summary>
    /// <param name="numberOfRolls">The number of times to roll the two dice</param>
    /// <returns>An integer array of size 13, where indices 2-12 contain the count of each sum.
    /// Indices 0 and 1 are unused since dice sums start at 2 (minimum 1+1).</returns>
    public int[] SimulateRolls(int numberOfRolls)
    {
        // Create an array of size 13 to store the results
        // We use size 13 (indices 0-12) so that we can directly use the sum (2-12) as an index
        // Indices 0 and 1 will remain 0 since the minimum sum of two dice is 2
        int[] results = new int[13];

        // Loop for the specified number of rolls
        // This is a for loop: it repeats a block of code a specific number of times
        // i starts at 0, continues while i < numberOfRolls, and increments by 1 each iteration
        for (int i = 0; i < numberOfRolls; i++)
        {
            // Simulate rolling the first 6-sided die
            // Random.Next(1, 7) generates a random integer from 1 to 6 (inclusive)
            // The first parameter (1) is inclusive, the second (7) is exclusive
            int die1 = random.Next(1, 7);

            // Simulate rolling the second 6-sided die
            // We roll a second die independently to simulate two separate dice
            int die2 = random.Next(1, 7);

            // Calculate the sum of the two dice
            // This represents the result of rolling two dice together
            int sum = die1 + die2;

            // Increment the count for this sum in our results array
            // For example, if sum is 7, we increment results[7]
            // The ++ operator adds 1 to the current value
            results[sum]++;
        }

        // Return the array containing all the roll results
        // This array will be used by the calling code to display the histogram
        return results;
    }
}

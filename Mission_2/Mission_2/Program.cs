// LUKE MILLER
// IS 413 - MISSION 2
// SECTION 2 GROUP 15

// This line declares that this code belongs to the "Mission_2" namespace
// A namespace is like a container that groups related code together
// It helps organize code and avoid naming conflicts
namespace Mission_2;

/// <summary>
/// The Program class contains the Main method, which is the entry point of the application.
/// When you run a C# console application, execution starts at the Main method.
/// </summary>
class Program
{
    /// <summary>
    /// The Main method is the entry point of the program.
    /// It must be static (belongs to the class, not an instance) and void (returns nothing).
    /// The string[] args parameter can receive command-line arguments, but we won't use it here.
    /// </summary>
    /// <param name="args">Command-line arguments (not used in this program)</param>
    static void Main(string[] args)
    {
        // Display a welcome message to the user
        // Console.WriteLine() prints text to the console and moves to the next line
        Console.WriteLine("Welcome to the dice throwing simulator!");
        
        // Print an empty line for better readability (visual spacing)
        Console.WriteLine();

        // Prompt the user to enter how many dice rolls they want to simulate
        // Console.Write() prints text without moving to the next line
        // We use Write instead of WriteLine so the user's input appears on the same line
        Console.Write("How many dice rolls would you like to simulate? ");

        // Read the user's input from the console
        // Console.ReadLine() waits for the user to type something and press Enter
        // It returns a string (text) containing what the user typed
        string? userInput = Console.ReadLine();

        // Convert the string input to an integer
        // Since user input is always text, we need to convert it to a number
        // int.Parse() converts a string to an integer
        // The ? after string means it could be null (empty), so we use ?? "0" as a fallback
        // If userInput is null, we use "0" instead
        int numberOfRolls = int.Parse(userInput ?? "0");

        // Create an instance of the DiceRoller class
        // The "new" keyword creates a new object (instance) of the DiceRoller class
        // We need an instance because the SimulateRolls method is not static
        DiceRoller diceRoller = new DiceRoller();

        // Call the SimulateRolls method on our diceRoller object
        // This method simulates rolling two dice the specified number of times
        // It returns an array where each index (2-12) contains the count of that sum
        // We store the returned array in a variable called "rollResults"
        int[] rollResults = diceRoller.SimulateRolls(numberOfRolls);

        // Print an empty line for spacing
        Console.WriteLine();

        // Display the header for the results section
        Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        
        // Display the explanation of what the asterisks represent
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        
        // Display the total number of rolls that were simulated
        // We use string interpolation ($"...") to insert the variable value into the string
        // The {numberOfRolls} gets replaced with the actual number
        Console.WriteLine($"Total number of rolls = {numberOfRolls}.");

        // Loop through each possible dice sum from 2 to 12
        // We start at 2 because that's the minimum sum (1+1) of two 6-sided dice
        // We go up to 12 because that's the maximum sum (6+6) of two 6-sided dice
        // The <= operator means "less than or equal to"
        for (int sum = 2; sum <= 12; sum++)
        {
            // Get the count of how many times this sum was rolled
            // We access the array using the sum as the index
            // For example, if sum is 7, we get rollResults[7]
            int count = rollResults[sum];

            // Calculate the percentage of total rolls that this sum represents
            // We multiply by 100.0 to convert to percentage (e.g., 0.15 becomes 15.0)
            // We use 100.0 (with decimal) instead of 100 (integer) to ensure decimal division
            // If we used 100, integer division would truncate the decimal part
            double percentage = (count * 100.0) / numberOfRolls;

            // Round the percentage to the nearest integer
            // Math.Round() rounds a decimal number to the nearest whole number
            // We convert it to int because we need a whole number of asterisks
            // For example, 15.7% rounds to 16 asterisks, 15.3% rounds to 15 asterisks
            int asteriskCount = (int)Math.Round(percentage);

            // Display the sum followed by a colon and space
            // We use Console.Write() so the asterisks appear on the same line
            Console.Write($"{sum}: ");

            // Print asterisks to represent the percentage
            // Each asterisk represents 1% of the total rolls
            // We loop from 0 to asteriskCount (exclusive) to print that many asterisks
            for (int i = 0; i < asteriskCount; i++)
            {
                // Print a single asterisk without moving to the next line
                Console.Write("*");
            }

            // Move to the next line after printing all asterisks for this sum
            // This prepares the console for the next sum's histogram line
            Console.WriteLine();
        }

        // Print an empty line for spacing before the goodbye message
        Console.WriteLine();

        // Display a goodbye message to the user
        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }
}
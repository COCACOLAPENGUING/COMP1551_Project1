using System;
using System.Linq;

namespace COMP1551_Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; // Declare n only once!

            // Prompt user to enter a valid string
            Console.Write("Enter a string (A-Z only, max 40): ");
            string s = Console.ReadLine(); // Don't convert to uppercase yet

            // Validate input: only uppercase letters and max length of 40
            while (s.Length > 40 || !IsValidInput(s))
            {
                Console.WriteLine("⚠️  Invalid input. Please enter a string containing only uppercase letters (A-Z) with a maximum length of 40.");
                Console.Write("Enter a string (A-Z only, max 40): ");
                s = Console.ReadLine(); // Re-prompt for input
            }

            // Convert the input to uppercase after validation
            s = s.ToUpper();

            // Sort the string alphabetically, including digits
            string sortedString = new string(s.OrderBy(c => c).ToArray());

            // Sort the ASCII codes of the sorted string
            int[] sortedAsciiCodes = sortedString.Select(c => (int)c).ToArray();

            // Prompt for N value between -25 and 25
            while (true)
            {
                Console.Write("Enter N (-25 to 25): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= -25 && n <= 25)
                {
                    break; // Valid, exit loop
                }
                Console.WriteLine("⚠️  Invalid input. Please enter a number between -25 and 25.");
            }

            // Encoding method options
            Console.WriteLine("\nChoose encoding method:");
            Console.WriteLine(" 1. Caesar Cipher");
            Console.WriteLine(" 2. Atbash Cipher");
            Console.WriteLine(" 3. Adjacent Swap");
            Console.WriteLine(" 4. Vowel Replacer");
            Console.WriteLine(" 5. Mirror Mode");
            Console.Write("Your choice: ");
            int choice = int.Parse(Console.ReadLine());

            StringProcessorBase processor;

            // Select encoding method based on user choice
            switch (choice)
            {
                case 1:
                    processor = new CaesarProcessor(s, n);
                    break;
                case 2:
                    processor = new AtbashProcessor(s);
                    break;
                case 3:
                    processor = new AdjacentSwapProcessor(s);
                    break;
                case 4:
                    processor = new VowelReplacerProcessor(s);
                    break;
                case 5:
                    processor = new MirrorProcessor(s);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;
            }

            // Output the sorted string and ASCII codes
            Console.WriteLine($"\nSorted String: {sortedString}");
            Console.WriteLine($"Sorted ASCII Codes: {string.Join(", ", sortedAsciiCodes)}");

            Console.WriteLine($"\nEncoded     : {processor.Print()}");
            Console.WriteLine($"Input ASCII : {string.Join(", ", processor.InputCode())}");
            Console.WriteLine($"Output ASCII: {string.Join(", ", processor.OutputCode())}");

            // Wait for user input before exiting
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Helper method to check if the string contains only valid uppercase letters
        static bool IsValidInput(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsUpper(c))
                {
                    return false; // Return false if any character is not an uppercase letter
                }
            }
            return true; // Return true if all characters are valid uppercase letters
        }
    }
}
=
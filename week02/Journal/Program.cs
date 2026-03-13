using System;

namespace Journal;

class Program
{
    static Journal journal = new Journal();

    static void Main(string[] args)
    {
        bool runProgram = true;
        while (runProgram)
        {
            Console.Clear();
            Console.WriteLine("=== Journal Program ===");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Quit");
            Console.Write("Select option (1-5): ");
            string choiceStr = Console.ReadLine();
            if (int.TryParse(choiceStr, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        journal.AddEntry();
                        break;
                    case 2:
                        journal.DisplayAll();
                        break;
                    case 3:
                        Console.Write("Enter filename: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;
                    case 4:
                        Console.Write("Enter filename: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;
                    case 5:
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue.");
            }
            if (runProgram)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Goodbye!");
    }
}

// Exceeded requirements: 
// - Proper CSV handling in Entry/Journal with quoting for fields containing commas, quotes, or | separator.
// - 7 prompts (extra creativity).
// - Abstraction: Private lists/methods hide implementation.
// - Matches demo flow: Menu loop, clear screen, pause between actions.


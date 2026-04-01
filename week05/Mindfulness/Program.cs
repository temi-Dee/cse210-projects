using System;
using System.Collections.Generic;

// Exceeds requirements:
// 1. Tracks a session log showing how many times each activity was completed.
//    The log is displayed in the menu after each activity so the user can see
//    their progress for the current session.
// 2. Prompts and questions in Reflection and Listing activities are shuffled
//    so all items are used before any repeats occur within a session.

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> sessionLog = new Dictionary<string, int>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            if (sessionLog.Count > 0)
            {
                Console.WriteLine("\n--- Session Log ---");
                foreach (var entry in sessionLog)
                    Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
            }

            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                LogActivity(sessionLog, activity.GetName());
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                LogActivity(sessionLog, activity.GetName());
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                LogActivity(sessionLog, activity.GetName());
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nGoodbye!");
                break;
            }
        }
    }

    static void LogActivity(Dictionary<string, int> log, string name)
    {
        if (log.ContainsKey(name))
            log[name]++;
        else
            log[name] = 1;
    }
}

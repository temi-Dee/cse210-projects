using System;

// Exceeds core requirements in two ways:
//
// 1. NEGATIVE GOALS: A new NegativeGoal class (derived from Goal) lets users
//    track bad habits they want to break. Recording a negative goal deducts
//    points from the score, adding a real consequence for slipping up.
//
// 2. LEVEL SYSTEM: The program calculates and displays the user's current
//    level based on their score (every 1000 points = 1 level). Each level
//    has a title (Novice, Apprentice, Journeyman, Expert, Master, Legend).
//    The level and a progress bar toward the next level are shown in the menu,
//    giving the user a motivating visual of their progress.

class Program
{
    static string GetLevel(int score, out int nextLevelAt)
    {
        string[] titles = { "Novice", "Apprentice", "Journeyman", "Expert", "Master", "Legend" };
        int level = score / 1000;
        int titleIndex = Math.Min(level, titles.Length - 1);
        nextLevelAt = (level + 1) * 1000;
        return $"Level {level + 1} {titles[titleIndex]}";
    }

    static string GetProgressBar(int score)
    {
        int progress = score % 1000;
        int filled = progress / 100;
        return "[" + new string('#', filled) + new string('-', 10 - filled) + $"] {progress}/1000";
    }

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.Clear();
            int score = manager.GetScore();
            string level = GetLevel(score, out int nextLevelAt);
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Score: {score}  |  {level}");
            Console.WriteLine($"Next level: {GetProgressBar(score)}\n");

            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
                manager.CreateGoal();
            else if (choice == "2")
                manager.DisplayGoals();
            else if (choice == "3")
                manager.RecordEvent();
            else if (choice == "4")
                manager.SaveGoals();
            else if (choice == "5")
                manager.LoadGoals();
            else if (choice == "6")
                break;

            if (choice != "6")
            {
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}

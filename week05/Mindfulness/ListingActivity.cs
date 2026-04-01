using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    public void Run()
    {
        DisplayStartMessage();

        List<string> shuffledPrompts = Shuffle(_prompts);
        Console.WriteLine($"\n{shuffledPrompts[0]}");
        Console.WriteLine("\nYou have 5 seconds to think before you begin...");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("\nStart listing items (press Enter after each one):");
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                items.Add(item);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndMessage();
    }
}

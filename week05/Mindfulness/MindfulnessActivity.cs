using System;
using System.Collections.Generic;
using System.Threading;

public class MindfulnessActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName() => _name;

    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long would you like this activity to last (in seconds)? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        int total = seconds * 10;
        for (int i = 0; i < total; i++)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(100);
            Console.Write("\b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected List<T> Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        List<T> copy = new List<T>(list);
        for (int i = copy.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            T temp = copy[i];
            copy[i] = copy[j];
            copy[j] = temp;
        }
        return copy;
    }
}

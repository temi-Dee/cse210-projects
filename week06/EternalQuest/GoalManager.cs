using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public int GetScore() => _score;

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal types:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (lose points for bad habits)");
        Console.Write("Choose type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points per event: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Required number of times: ");
            int required = int.Parse(Console.ReadLine());
            Console.Write("Bonus points on completion: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, required, bonus));
        }
        else if (type == "4")
        {
            _goals.Add(new NegativeGoal(name, desc, points));
        }

        Console.WriteLine("Goal created!");
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet.");
            return;
        }
        Console.WriteLine();
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
    }

    public void RecordEvent()
    {
        DisplayGoals();
        if (_goals.Count == 0) return;

        Console.Write("\nWhich goal did you accomplish? (number): ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        if (earned > 0)
        {
            _score += earned;
            Console.WriteLine($"You earned {earned} points! Total score: {_score}");
        }
        else if (earned < 0)
        {
            _score += earned;
            Console.WriteLine($"You lost {Math.Abs(earned)} points. Total score: {_score}");
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
                writer.WriteLine(g.GetSaveString());
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("Filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            else if (type == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
            else if (type == "NegativeGoal")
                _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
        }

        Console.WriteLine("Goals loaded!");
    }
}

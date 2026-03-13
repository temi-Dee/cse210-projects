using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Journal
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();
        private List<string> _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What did I learn today?"
        };

        public void AddEntry()
        {
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("> ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToShortDateString();
            Entry entry = new Entry(date, prompt, response);
            _entries.Add(entry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries yet.");
                return;
            }
            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();  // Extra line between entries
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename, false))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToCsvString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();
            foreach (string line in lines)
            {
                try
                {
                    Entry entry = Entry.FromCsvString(line);
                    _entries.Add(entry);
                }
                catch
                {
                    // Skip invalid lines
                }
            }
            Console.WriteLine($"Journal loaded from {filename} ({_entries.Count} entries)");
        }
    }
}

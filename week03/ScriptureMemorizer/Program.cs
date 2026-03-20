using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Exceeds core requirements:
    /// - Library of 3+ scriptures with random selection at start for replay value.
    /// - Hides only unhidden words randomly (stretch goal).
    /// - Handles verse ranges (e.g. Proverbs 3:5-6).
    /// - Proper encapsulation across Reference/Word/Scripture classes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Scripture library (exceeds core: multiple, random pick)
            var scriptures = new List<(string reference, string text)>
            {
                ("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                ("Proverbs 3:5-6", "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                ("Moroni 10:4-5", "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.")
            };

            // Pick random scripture
            var random = new Random();
            var selected = scriptures[random.Next(scriptures.Count)];
            var scripture = new Scripture(selected.reference, selected.text);

            Console.WriteLine("Welcome to Scripture Memorizer! Press Enter to hide words, or 'quit' to exit.");

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words hidden! Great job memorizing!");
                    break;
                }

                Console.Write("\nPress Enter to continue or type 'quit' to exit: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("Thanks for using Scripture Memorizer!");
                    break;
                }

                // Hide 2 random unhidden words
                scripture.HideRandomWords(2);
            }
        }
    }
}

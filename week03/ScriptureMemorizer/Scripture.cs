using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        /// <summary>
        /// Constructor: Parses reference string (e.g. "John 3:16" or "Proverbs 3:5-6"), splits text into Words.
        /// Simple parsing: split on spaces for words (ignores punctuation for core reqs).
        /// </summary>
        public Scripture(string referenceText, string fullText)
        {
            // Parse reference: assume "Book Chapter:verses"
            string[] refParts = referenceText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string book = refParts[0];
            string[] chapVerse = refParts[1].Split(':');
            int chapter = int.Parse(chapVerse[0]);

            string versePart = chapVerse[1];
            if (versePart.Contains('-'))
            {
                string[] verses = versePart.Split('-');
                int startVerse = int.Parse(verses[0]);
                int endVerse = int.Parse(verses[1]);
                _reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(versePart);
                _reference = new Reference(book, chapter, verse);
            }

            // Split text into words (simple space split)
            string[] wordTexts = fullText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _words = wordTexts.Select(text => new Word(text)).ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference.GetDisplayText());
            Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
        }

        /// <summary>
        /// Hides up to 2 random unhidden words (stretch: only unhid).
        /// </summary>
        public void HideRandomWords(int count = 2)
        {
            var unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();
            if (unhiddenWords.Count == 0) return;

            int toHide = Math.Min(count, unhiddenWords.Count);
            for (int i = 0; i < toHide; i++)
            {
                // Shuffle to pick random
                int randomIndex = new Random().Next(unhiddenWords.Count);
                var wordToHide = unhiddenWords[randomIndex];
                wordToHide.Hide();
                unhiddenWords.Remove(wordToHide);  // Avoid re-hide
            }
        }

        public bool AllWordsHidden()
        {
            return !_words.Any(w => !w.IsHidden());
        }
    }
}


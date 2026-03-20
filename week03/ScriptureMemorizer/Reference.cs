using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;

        /// <summary>
        /// Constructor for single verse reference, e.g., "John", 3, 16
        /// </summary>
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
        }

        /// <summary>
        /// Constructor for verse range reference, e.g., "Proverbs", 3, 5, 6
        /// </summary>
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        /// <summary>
        /// Returns formatted display text: "Book Chapter:verse" or "Book Chapter:start-end"
        /// </summary>
        public string GetDisplayText()
        {
            string verseText = _startVerse == _endVerse
                ? $"{_startVerse}"
                : $"{_startVerse}-{_endVerse}";
            return $"{_book} {_chapter}:{verseText}";
        }
    }
}


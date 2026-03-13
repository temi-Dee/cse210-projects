using System;

namespace Journal
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public void Display()
        {
            Console.WriteLine($"{Date}: {Prompt}");
            Console.WriteLine($"  \"{Response}\"");
        }

        public string ToCsvString()
        {
            return $"{EscapeCsv(Date)}|{EscapeCsv(Prompt)}|{EscapeCsv(Response)}";
        }

        public static Entry FromCsvString(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 3) throw new ArgumentException("Invalid CSV line");

            return new Entry(UnescapeCsv(parts[0]), UnescapeCsv(parts[1]), UnescapeCsv(parts[2]));
        }

        private static string EscapeCsv(string field)
        {
            if (field.Contains(',') || field.Contains('"') || field.Contains('|'))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }

        private static string UnescapeCsv(string field)
        {
            if (field.StartsWith("\"") && field.EndsWith("\""))
            {
                field = field.Substring(1, field.Length - 2);
                return field.Replace("\"\"", "\"");
            }
            return field;
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }

    public class Journal
    {
        private List<Entry> entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            while (true)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Random random = new Random();
                        string prompt = prompts[random.Next(prompts.Count)];
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        string date = DateTime.Now.ToShortDateString();
                        journal.AddEntry(new Entry(prompt, response, date));
                        break;

                    case "2":
                        Console.WriteLine("\nJournal Entries:");
                        journal.DisplayEntries();
                        break;

                    case "3":
                        Console.Write("Enter filename to save: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case "4":
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

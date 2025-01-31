using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); 
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string reference)
    {
        var parts = reference.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
        Book = parts[0];
        Chapter = int.Parse(parts[1]);
        StartVerse = int.Parse(parts[2]);
        if (parts.Length > 3)
        {
            EndVerse = int.Parse(parts[3]);
        }
    }

    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n" + string.Join(" ", _words);
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}

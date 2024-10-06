using System;

class Program
{
    using System.Collections.Generic;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filePath)
    {
        // Placeholder code for saving to file
    }

    public void LoadFromFile(string filePath)
    {
        // Placeholder code for loading from file
    }
}


    public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public void Display()
    {
        // Display the entry's date and text
        Console.WriteLine($"{_date}: {_entryText}");
    }
}

    using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "What made you smile today?",
        "What are you grateful for?",
        "What challenges did you face today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

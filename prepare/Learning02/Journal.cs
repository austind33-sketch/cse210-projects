using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List to store journal entries
    private List<Entry> _entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
        }
        else
        {
            foreach (var entry in _entries)
            {
                entry.Display();
            }
        }
    }

    // Save all journal entries to a file
    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.GetDate());
                writer.WriteLine(entry.GetPromptText());
                writer.WriteLine(entry.GetEntryText());
                writer.WriteLine("---");  // Separator between entries
            }
        }
        Console.WriteLine($"Journal saved to {fileName}");
    }

    // Load journal entries from a file
    public void LoadFromFile(string fileName)
    {
        _entries.Clear(); // Clear the current journal entries before loading new ones

        string[] lines = File.ReadAllLines(fileName);

        for (int i = 0; i < lines.Length; i += 4) // Reading 4 lines at a time (date, prompt, entry, separator)
        {
            string date = lines[i];
            string prompt = lines[i + 1];
            string entryText = lines[i + 2];

            Entry entry = new Entry(prompt, entryText);
            _entries.Add(entry);
        }
        Console.WriteLine($"Journal loaded from {fileName}");
    }
}

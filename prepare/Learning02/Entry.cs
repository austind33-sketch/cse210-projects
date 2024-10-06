using System;

public class Entry
{
    // Private attributes to store entry details
    private string _date;
    private string _promptText;
    private string _entryText;

    // Constructor to initialize an entry with a prompt and user response
    public Entry(string prompt, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Store current date and time
        _promptText = prompt;
        _entryText = entryText;
    }

    // Method to display entry details
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    // Getters to retrieve entry details (used for saving entries to file)
    public string GetDate() => _date;
    public string GetPromptText() => _promptText;
    public string GetEntryText() => _entryText;
}

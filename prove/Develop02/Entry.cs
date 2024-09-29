using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood; 
    private string _location; 

    public Entry(string date, string promptText, string entryText, string mood, string location)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
        _location = location;
    }

    public string GetDate() => _date;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Location: {_location}");
    }

    public string ToCsv()
    {
        return $"\"{_date}\",\"{_promptText}\",\"{_entryText}\",\"{_mood}\",\"{_location}\"";
    }

    public static Entry FromCsv(string csvLine)
    {
        var values = csvLine.Split(',');
        return new Entry(values[0].Trim('"'), values[1].Trim('"'), values[2].Trim('"'), values[3].Trim('"'), values[4].Trim('"'));
    }
}

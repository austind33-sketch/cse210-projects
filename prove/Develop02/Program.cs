using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Enter your response: ");
                    string entryText = Console.ReadLine();

                    Console.Write("Enter your mood: ");
                    string mood = Console.ReadLine();

                    Console.Write("Enter your location: ");
                    string location = Console.ReadLine();

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    var entry = new Entry(timestamp, prompt, entryText, mood, location);
                    journal.AddEntry(entry);

                    Console.WriteLine("Entry created successfully!");
                    Console.WriteLine("Would you like to save this entry? (yes/no)");
                    string saveChoice = Console.ReadLine();

                    if (saveChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter filename to save (with .csv extension): ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        Console.WriteLine("Journal entries saved.");
                    }
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (with .csv extension): ");
                    string saveToFile = Console.ReadLine();
                    journal.SaveToFile(saveToFile);
                    Console.WriteLine("Journal entries saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load (with .csv extension): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal entries loaded.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

// I was inspired by my Iphone health app to add more options to make the Journal more helpful.
// I added prompts to record current mood and location when making a Journal entry.
// I also made saving an entry to the journal more intuitive by prompting the user to save after making an entry prior to sending them to them main menu.The journal is saved to a CSV file, which can easily be opened in Excel for further analysis or backup.
// I also made it so that each entry is automatically time stamped.
// I made it so that the program can can also load entries from a CSV file, allowing users to retrieve their saved journal entries.
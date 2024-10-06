using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Instantiate the Journal and PromptGenerator objects
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool isRunning = true;

        while (isRunning)
        {
            // Display the user menu
            Console.WriteLine("=== Journal Menu ===");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display all journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Create a new journal entry
                    string prompt = promptGenerator.GetRandomPrompt(); // Get a random prompt
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry(prompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    // Display all journal entries
                    journal.DisplayAll();
                    break;

                case "3":
                    // Save journal entries to a file
                    Console.Write("Enter the file name to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;

                case "4":
                    // Load journal entries from a file
                    Console.Write("Enter the file name to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case "5":
                    // Exit the program
                    isRunning = false;
                    Console.WriteLine("Exiting the journal program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }

            Console.WriteLine(); // Add some space between operations
        }
    }
}

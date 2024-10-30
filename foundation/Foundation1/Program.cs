using System;

class Program
{
    static void Main(string[] args)
    {
        bool runAgain = true;

        while (runAgain)
        {
            Console.WriteLine("Enter the book name (e.g., Proverbs):");
            string book = Console.ReadLine();

            Console.WriteLine("Enter the chapter (e.g., 3):");
            int chapter = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the starting verse (e.g., 5):");
            int startVerse = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the ending verse (if applicable, or press Enter to skip):");
            string endVerseInput = Console.ReadLine();
            int endVerse = string.IsNullOrEmpty(endVerseInput) ? startVerse : int.Parse(endVerseInput);

            Console.WriteLine("Enter the scripture text:");
            string scriptureText = Console.ReadLine();

            Scripture scripture = new Scripture(new Reference(book, chapter, startVerse, endVerse), scriptureText);

            while (true)
            {
                SafeClearConsole();
                scripture.Display();

                if (scripture.IsFullyHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Would you like to:");
                    Console.WriteLine("1. Study a new verse");
                    Console.WriteLine("2. Exit the program");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        SafeClearConsole();
                        break;
                    }
                    else if (choice == "2")
                    {
                        runAgain = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                    {
                        runAgain = false;
                        break;
                    }

                    scripture.HideRandomWords();
                }
            }
        }

        Console.WriteLine("\nProgram ended.");
    }

    static void SafeClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            Console.WriteLine("(Unable to clear the console in this environment. Proceeding without clearing.)");
        }
    }
}

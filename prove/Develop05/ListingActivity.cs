using System;

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "Who are your personal heroes?"
    };

    public override void Run()
    {
        Start();
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("List as many items as you can.");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter item: ");
            string item = Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
        End();
    }
}

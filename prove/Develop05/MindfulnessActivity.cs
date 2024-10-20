using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public virtual void Start()
    {
        Console.WriteLine($"Starting {GetType().Name}...");
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        DisplayAnimation();
    }

    public virtual void End()
    {
        Console.WriteLine($"\nGood job! You have completed the {GetType().Name} for {duration} seconds.");
        DisplayAnimation();
    }

    protected void DisplayAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}

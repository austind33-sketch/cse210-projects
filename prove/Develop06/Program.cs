using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        GoalTracker tracker = new GoalTracker();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    tracker.CreateGoal();
                    break;
                case "2":
                    tracker.ListGoals();
                    break;
                case "3":
                    tracker.SaveGoals("goals.txt");
                    break;
                case "4":
                    tracker.LoadGoals("goals.txt");
                    break;
                case "5":
                    tracker.RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

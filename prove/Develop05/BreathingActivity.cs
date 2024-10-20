using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public override void Run()
    {
        Start();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            BreathingAnimation("Breathe in...");
            BreathingAnimation("Breathe out...");
        }
        
        End();
    }

    private void BreathingAnimation(string message)
    {
        Console.WriteLine(message);
        for (int i = 1; i <= 5; i++)
        {
            Console.Write(new string(' ', i));
            Console.Write("O");
            Thread.Sleep(1000);
            Console.Write("\b \b" + new string('\b', i));
        }
        Console.WriteLine();
    }
}

using System;

class Program
{
    static void Main(string[] args)
    {
       

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,100);

        int guess = -1;

        while (guess != magicNumber)
        { 
             Console.Write("What is the number I'm thinking of?");
            int.Parse(Console.ReadLine());

            if (magicNumber == guess)
            {
                Console.Write("Correct!! It was" [magicNumber]);
            }
            else
            {
                Console.Write("Nope! Guess again");
            }
        }
    }
}
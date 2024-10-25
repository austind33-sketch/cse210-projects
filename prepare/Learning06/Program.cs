using System;

class Program
{
    static void Main()
    {
        DisplayMessage();

        string userName = AskForUserName();
        int userNumber = AskForFavoriteNumber();

        int squaredNumber = CalculateSquare(userNumber);

        ShowResult(userName, squaredNumber);
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to my Program!");
    }

    static string AskForUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int AskForFavoriteNumber()
    {
        Console.Write("What is your favorite number? ");
        return int.Parse(Console.ReadLine());
    }

    static int CalculateSquare(int number)
    {
        return number * number;
    }

    static void ShowResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNumber}!");
        Console.WriteLine("Have a nice day!");
    }
}

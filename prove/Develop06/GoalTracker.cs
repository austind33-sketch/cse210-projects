using System;
using System.Collections.Generic;
using System.IO;

class GoalTracker
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;
    private int level = 0;
    private static readonly string[] levels = { "F-ranked Adventurer", "E-ranked Adventurer", "D-ranked Adventurer", "C-ranked Adventurer", "B-ranked Adventurer", "A-ranked Adventurer", "S-ranked Adventurer" };
    
    public void AddPoints(int points)
    {
        score += points;
    }

    public void CheckLevelUp()
    {
        if (score >= (level + 1) * 1000 && level < levels.Length - 1)
        {
            level++;
            Console.WriteLine($"Level Up! You are now a {levels[level]} with {score} points.");
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.WriteLine("Goal Type:\n1. Simple\n2. Eternal\n3. Checklist");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter points: ");
                goals.Add(new SimpleGoal(description, int.Parse(Console.ReadLine())));
                break;
            case "2":
                Console.Write("Enter points per completion: ");
                goals.Add(new EternalGoal(description, int.Parse(Console.ReadLine())));
                break;
            case "3":
                Console.Write("Enter points per completion: ");
                int points = int.Parse(Console.ReadLine());
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points on completion: ");
                goals.Add(new ChecklistGoal(description, points, targetCount, int.Parse(Console.ReadLine())));
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    public void ListGoals()
    {
        foreach (var goal in goals)
            Console.WriteLine(goal);
        Console.WriteLine($"Current Score: {score}");
        Console.WriteLine($"Rank: {levels[level]}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            writer.WriteLine(level);
            foreach (var goal in goals)
            {
                if (goal is SimpleGoal)
                    writer.WriteLine($"Simple,{goal.Description},{goal.Points},{goal.IsComplete}");
                else if (goal is EternalGoal)
                    writer.WriteLine($"Eternal,{goal.Description},{goal.Points}");
                else if (goal is ChecklistGoal checklistGoal)
                    writer.WriteLine($"Checklist,{goal.Description},{goal.Points},{checklistGoal.TargetCount},{checklistGoal.CurrentCount},{goal.IsComplete},{checklistGoal.BonusPoints}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            score = int.Parse(reader.ReadLine());
            level = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                switch (parts[0])
                {
                    case "Simple":
                        SimpleGoal simpleGoal = new SimpleGoal(parts[1], int.Parse(parts[2]));
                        simpleGoal.IsComplete = bool.Parse(parts[3]);
                        goals.Add(simpleGoal);
                        break;
                    case "Eternal":
                        goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                        break;
                    case "Checklist":
                        ChecklistGoal checklistGoal = new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[5]))
                        {
                            CurrentCount = int.Parse(parts[4]),
                            IsComplete = bool.Parse(parts[6])
                        };
                        goals.Add(checklistGoal);
                        break;
                }
            }
        }
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter the goal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= goals.Count)
            goals[index - 1].RecordEvent(this);
        else
            Console.WriteLine("Invalid goal number.");
    }
}


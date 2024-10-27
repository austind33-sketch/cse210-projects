using System;

abstract class Goal
{
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; internal set; }

    public Goal(string description, int points)
    {
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent(GoalTracker tracker);
    public abstract override string ToString();
}

class ChecklistGoal : Goal
{
    public int TargetCount { get; }
    public int CurrentCount { get; internal set; }
    public int BonusPoints { get; }

    public void IncrementCount()
{
    CurrentCount++;
    if (CurrentCount >= TargetCount)  // assuming there's a TargetCount
    {
        IsComplete = true;
    }
}

    public ChecklistGoal(string description, int points, int targetCount, int bonusPoints)
        : base(description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent(GoalTracker tracker)
    {
        CurrentCount++;
        tracker.AddPoints(Points);

        if (CurrentCount >= TargetCount && !IsComplete)
        {
            tracker.AddPoints(BonusPoints);
            IsComplete = true;
        }
        tracker.CheckLevelUp();
    }

    public override string ToString()
    {
        return $"[Checklist Goal] {Description} - {CurrentCount}/{TargetCount}, {(IsComplete ? "Complete" : "Incomplete")}, {Points} Points, Bonus {BonusPoints}";
    }
}

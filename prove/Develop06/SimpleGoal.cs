class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points) { }

    public override void RecordEvent(GoalTracker tracker)
    {
        if (!IsComplete)
        {
            tracker.AddPoints(Points);
            IsComplete = true;
            tracker.CheckLevelUp();
        }
    }

    public override string ToString()
    {
        return $"[Simple Goal] {Description} - {(IsComplete ? "Complete" : "Incomplete")}, {Points} Points";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points) { }

    public override void RecordEvent(GoalTracker tracker)
    {
        tracker.AddPoints(Points);
        tracker.CheckLevelUp();
    }

    public override string ToString()
    {
        return $"[Eternal Goal] {Description} - {Points} Points (Repeating)";
    }
}

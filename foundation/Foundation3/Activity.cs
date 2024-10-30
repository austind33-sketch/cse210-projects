using System;

public class Activity
{
    private string date;
    private int duration;

    public Activity(string date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public int Duration
    {
        get { return duration; }
    }

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public virtual string GetSummary()
    {
        return $"{date} {GetType().Name} ({duration} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.0} min per km";
    }
}

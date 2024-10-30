using System;

public class Activity
{
    private string _date;
    private int _duration;

    public Activity(string _date, int duration)
    {
        this._date = _date;
        this._duration = duration;
    }

    public int Duration
    {
        get { return _duration; }
    }

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_duration} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.0} min per km";
    }
}

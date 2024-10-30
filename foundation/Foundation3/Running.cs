using System;

public class Running : Activity
{
    private double _distance;

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        this._distance = distance;
    }

    public override double GetDistance() { return _distance; }
    public override double GetSpeed() { return (_distance / Duration) * 60; }
    public override double GetPace() { return Duration / _distance; }
}

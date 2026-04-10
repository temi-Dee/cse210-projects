public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
        int requiredCount, int bonusPoints, int timesCompleted = 0)
        : base(name, description, points)
    {
        _requiredCount = requiredCount;
        _bonusPoints = bonusPoints;
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;
        _timesCompleted++;
        int earned = _points;
        if (_timesCompleted == _requiredCount)
            earned += _bonusPoints;
        return earned;
    }

    public override bool IsComplete() => _timesCompleted >= _requiredCount;

    public override string GetDisplayString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()}) -- Completed {_timesCompleted}/{_requiredCount} times";
    }

    public override string GetSaveString() =>
        $"ChecklistGoal|{GetName()}|{GetDescription()}|{_points}|{_requiredCount}|{_bonusPoints}|{_timesCompleted}";
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetDisplayString() =>
        $"[∞] {GetName()} ({GetDescription()})";

    public override string GetSaveString() =>
        $"EternalGoal|{GetName()}|{GetDescription()}|{_points}";
}

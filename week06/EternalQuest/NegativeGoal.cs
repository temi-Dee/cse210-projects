public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => -_points;

    public override bool IsComplete() => false;

    public override string GetDisplayString() =>
        $"[-] {GetName()} ({GetDescription()}) -- -{_points} pts per occurrence";

    public override string GetSaveString() =>
        $"NegativeGoal|{GetName()}|{GetDescription()}|{_points}";
}

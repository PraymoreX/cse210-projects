public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
        _isComplete = currentCount >= targetCount;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
            return 0;

        _currentCount++;
        int earned = _points;

        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name}|{_description}|{_points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}
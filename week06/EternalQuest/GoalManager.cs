using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private int GetLevel()
    {
    return (_score / 500) + 1;
    }

    public bool HasGoals()
    {
        return _goals.Count > 0;
    }

    public void DisplayGoals()
{
    Console.WriteLine($"\nScore: {_score}");
    Console.WriteLine($"Level: {GetLevel()}\n");

    for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
}

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
            return;

        _score += _goals[index].RecordEvent();
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void Load(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            if (parts.Length < 2) continue;

            string type = parts[0];
            string[] data = parts[1].Split('|');

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(
                    data[0], data[1], int.Parse(data[2]),
                    bool.Parse(data[3])
                ));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    data[0], data[1], int.Parse(data[2])
                ));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    int.Parse(data[3]),
                    int.Parse(data[4]),
                    int.Parse(data[5])
                ));
            }
        }
    }
}
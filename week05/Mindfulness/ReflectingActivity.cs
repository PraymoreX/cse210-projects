using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "How can you use this experience in the future?"
    };

    private List<string> _usedPrompts = new List<string>(); 

    public ReflectingActivity()
        : base("Reflecting", "Reflect on times you showed strength and resilience.")
    {
    }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();

        string prompt;
        do
        {
            prompt = _prompts[rand.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);

        Console.WriteLine("\nReflect on this prompt:");
        Console.WriteLine(prompt);

        Console.WriteLine("\nThink deeply...");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("\n" + question);
            ShowSpinner(4);
        }

        EndMessage();
    }
}
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "Who are your personal heroes?"
    };

    private List<string> _usedPrompts = new List<string>(); 

    public ListingActivity()
        : base("Listing", "List as many positive things as you can.")
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

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine(prompt);

        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");

        EndMessage();
    }
}
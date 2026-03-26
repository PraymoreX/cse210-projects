// Creativity: Allows user to select from multiple scriptures instead of one

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son"));

        scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding"));

        Console.WriteLine("Choose a scripture (1 or 2): ");
        int choice = int.Parse(Console.ReadLine());

        Scripture selectedScripture = scriptures[choice - 1];

        while (true)
        {
            Console.Clear();
            selectedScripture.Display();

            if (selectedScripture.AllHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit'");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords();
        }
    }
}
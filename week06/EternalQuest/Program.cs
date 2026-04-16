// Creativity: Added a level system where the user increases levels based on score.

using System;

class Program
{
    static GoalManager manager = new GoalManager();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                manager.DisplayGoals();
            }
            else if (choice == "2")
            {
                CreateGoal();
            }
            else if (choice == "3")
            {
            Console.WriteLine("\n=== Your Goals ===");
            manager.DisplayGoals();

                if (manager.HasGoals())
                {
                    Console.Write("\nEnter goal number: ");

                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        manager.RecordEvent(index - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("No goals available. Please add a goal first.");
                }
            }
            else if (choice == "4")
            {
                manager.Save("goals.txt");
            }
            else if (choice == "5")
            {
                manager.Load("goals.txt");
            }
            else if (choice == "6")
            {
                running = false;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            manager.AddGoal(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            manager.AddGoal(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }
}
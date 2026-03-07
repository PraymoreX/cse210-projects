using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int gradePercentage = int.Parse(answer);
        string grade;

        if(gradePercentage >= 90)
        {
            grade = "A";
        }
        else if(gradePercentage >= 80)
        {
            grade = "B";

        }
        else if(gradePercentage >= 70)
        {
            grade = "C";
        }
        else if(gradePercentage >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine($"Your grade is: {grade}");
        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
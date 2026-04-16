using System;

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("13 Apr 2026", 50, 2.0));
        activities.Add(new Cycling("21 Apr 2026", 10, 7.0));
        activities.Add(new Swimming("01 Apr 2026", 30, 30));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
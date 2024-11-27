using System;
using System.Collections.Generic;
using System.Linq;

class ActivitySelection
{
    public class Activity
    {
        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Activity(string name, int start, int end)
        {
            Name = name;
            Start = start;
            End = end;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Въведете броя на дейностите:");
        int n = int.Parse(Console.ReadLine());

        List<Activity> activities = new List<Activity>();

        Console.WriteLine("Въведете данните за всяка дейност във формат: име начало край");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int start = int.Parse(input[1]);
            int end = int.Parse(input[2]);

            activities.Add(new Activity(name, start, end));
        }

        // Сортиране по крайно време
        var sortedActivities = activities.OrderBy(a => a.End).ToList();

        List<Activity> selectedActivities = new List<Activity>();
        int lastEndTime = 0;

        foreach (var activity in sortedActivities)
        {
            if (activity.Start >= lastEndTime)
            {
                selectedActivities.Add(activity);
                lastEndTime = activity.End;
            }
        }

        Console.WriteLine("Избраните дейности са:");
        foreach (var activity in selectedActivities)
        {
            Console.WriteLine($"{activity.Name} ({activity.Start}, {activity.End})");
        }
    }
}
//8
//a1 1 3
//a2 0 4
//a3 1 2
//a4 4 6
//a5 2 9
//a6 5 8
//a7 3 5
//a8 4 5
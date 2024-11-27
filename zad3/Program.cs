using System;
using System.Collections.Generic;
using System.Linq;

class JobScheduling
{
    public class Job
    {
        public int Id { get; set; }
        public int Deadline { get; set; }
        public int Profit { get; set; }

        public Job(int id, int deadline, int profit)
        {
            Id = id;
            Deadline = deadline;
            Profit = profit;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Въведете броя на работните места:");
        int n = int.Parse(Console.ReadLine());

        List<Job> jobs = new List<Job>();

        Console.WriteLine("Въведете данните за всяка работа във формат: краен_срок печалба");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int deadline = int.Parse(input[0]);
            int profit = int.Parse(input[1]);

            jobs.Add(new Job(i + 1, deadline, profit));
        }

        // Сортиране на задачите по печалба в низходящ ред
        var sortedJobs = jobs.OrderByDescending(j => j.Profit).ToList();

        int maxDeadline = sortedJobs.Max(j => j.Deadline);

        int[] timeSlots = new int[maxDeadline];
        Array.Fill(timeSlots, -1);

        int totalProfit = 0;
        List<Job> selectedJobs = new List<Job>();

        // Опит за планиране на всяка задача
        foreach (var job in sortedJobs)
        {
            for (int t = job.Deadline - 1; t >= 0; t--)
            {
                if (timeSlots[t] == -1) // Ако времевият слот е свободен
                {
                    timeSlots[t] = job.Id;
                    totalProfit += job.Profit;
                    selectedJobs.Add(job);
                    break;
                }
            }
        }

        // Изход
        Console.WriteLine("Избраните задачи са:");
        foreach (var job in selectedJobs)
        {
            Console.WriteLine($"Работа {job.Id} (Краен срок: {job.Deadline}, Печалба: {job.Profit})");
        }

        Console.WriteLine($"Максимална печалба: {totalProfit}");
    }
}
//5
//2 60
//1 100
//3 20
//2 40
//1 20
using System;
using System.Collections.Generic;
using System.Linq;

class MagneticTape
{
    public class Program
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public double Probability { get; set; }

        public Program(int id, int length, double probability)
        {
            Id = id;
            Length = length;
            Probability = probability;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Въведете броя на програмите:");
        int n = int.Parse(Console.ReadLine());

        List<Program> programs = new List<Program>();

        Console.WriteLine("Въведете данните за всяка програма във формат: дължина вероятност");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int length = int.Parse(input[0]);
            double probability = double.Parse(input[1]);

            programs.Add(new Program(i + 1, length, probability));
        }

        // Сортиране по съотношението probability/length, после по оригиналния ред (Id)
        var sortedPrograms = programs
            .OrderByDescending(p => p.Probability / p.Length)
            .ThenBy(p => p.Id)
            .ToList();

        Console.WriteLine("Оптималната подредба на програмите е:");
        foreach (var program in sortedPrograms)
        {
            Console.WriteLine($"Програма {program.Id}");
        }
    }
}

//4
//1 0.3
//3 0.1
//2 0.5
//4 0.2
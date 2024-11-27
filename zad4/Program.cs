using System;
using System.Collections.Generic;
using System.Linq;

class SetCover
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Въведете елементите на вселената (разделени със запетаи):");
        var universe = new HashSet<int>(Console.ReadLine().Split(',').Select(int.Parse));

        Console.WriteLine("Въведете броя на подмножествата:");
        int n = int.Parse(Console.ReadLine());

        List<HashSet<int>> subsets = new List<HashSet<int>>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Въведете елементите на подмножество {i + 1} (разделени със запетаи):");
            subsets.Add(new HashSet<int>(Console.ReadLine().Split(',').Select(int.Parse)));
        }

        var selectedSubsets = new List<HashSet<int>>();
        while (universe.Count > 0)
        {
            var bestSubset = subsets
                .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                .First();

            selectedSubsets.Add(bestSubset);

            foreach (var element in bestSubset)
            {
                universe.Remove(element);
            }

            subsets.Remove(bestSubset);
        }

        Console.WriteLine("Избраните подмножества за покриване на вселената са:");
        foreach (var subset in selectedSubsets)
        {
            Console.WriteLine($"{{ {string.Join(", ", subset)} }}");
        }
    }
}

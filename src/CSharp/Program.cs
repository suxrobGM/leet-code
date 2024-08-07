﻿using LeetCode.Algorithms;
using LeetCode.DataStructures;
using LeetCode.Solutions;

public static class Program
{
    public static void Main(string[] args)
    {
        //BenchmarkLomuto();
        //BenchmarkHoare();
        //BenchmarkLargeSize();
        
        //var solution = new Solution887();
        //var output = solution.SuperEggDrop(1, 1);
        //Console.WriteLine(output);
        ColorGraph();
        Console.ReadLine();
    }
    
    private static void BenchmarkHoare()
    {
        int[] array = [2, 8, 7, 1, 3, 5, 6, 4];
        // int[] array = [8, 7, 6, 5, 4, 3, 2, 1];
        // int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var quickSort = new QuickSort<int>();
        
        quickSort.SortHoare(array);

        Console.WriteLine("\nHoare's partitioning scheme");
        Console.WriteLine("Sorted array: " + string.Join(", ", array));
        Console.WriteLine($"Comparisons: {quickSort.Comparisons}");
        Console.WriteLine($"Swaps: {quickSort.Swaps}");
        Console.WriteLine($"Time: {quickSort.ExecutionTime.TotalMilliseconds} ms");
    }

    private static void ColorGraph()
    {
        var graph = new Graph<char>();
        graph.AddEdge('a', 'b');
        graph.AddEdge('a', 'd');
        graph.AddEdge('a', 'e');
        graph.AddEdge('a', 'f');
        graph.AddEdge('b', 'c');
        graph.AddEdge('b', 'h');
        graph.AddEdge('b', 'j');
        graph.AddEdge('c', 'g');
        graph.AddEdge('c', 'd');
        graph.AddEdge('d', 'i');
        graph.AddEdge('d', 'k');
        graph.AddEdge('k', 'f');
        graph.AddEdge('k', 'h');
        graph.AddEdge('k', 'j');
        graph.AddEdge('j', 'i');
        graph.AddEdge('j', 'e');
        graph.AddEdge('e', 'g');
        graph.AddEdge('g', 'f');
        graph.AddEdge('g', 'i');
        graph.AddEdge('g', 'h');
        var colors = graph.GreedyColoring();
        
        Console.WriteLine("Coloring of vertices:");
        foreach (var (vertex, color) in colors)
        {
            Console.WriteLine($"{vertex}: {color}");
        }
    }
    
    private static void BenchmarkLomuto()
    {
        // int[] array = [2, 8, 7, 1, 3, 5, 6, 4];
        int[] array = [8, 7, 6, 5, 4, 3, 2, 1];
        // int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var quickSort = new QuickSort<int>();
        
        quickSort.SortLomuto(array);

        Console.WriteLine("\nLomuto's partitioning scheme");
        Console.WriteLine("Sorted array: " + string.Join(", ", array));
        Console.WriteLine($"Comparisons: {quickSort.Comparisons}");
        Console.WriteLine($"Swaps: {quickSort.Swaps}");
        Console.WriteLine($"Time: {quickSort.ExecutionTime.TotalMilliseconds} ms");
    }

    private static void BenchmarkLargeSize()
    {
        const int n = 1000; // Size of array
        const int iterations = 10000; // Number of permutations to test
        var random = new Random();
        var quickSort = new QuickSort<int>();
        
        var totalTimeLomuto = 0.0;
        var totalComparisonsLomuto = 0;
        var totalSwapsLomuto = 0;

        var totalTimeHoare = 0.0;
        var totalComparisonsHoare = 0;
        var totalSwapsHoare = 0;

        for (var i = 0; i < iterations; i++)
        {
            var array = Enumerable.Range(1, n).OrderBy(_ => random.Next(1, n)).ToArray();

            // Sort using Lomuto
            quickSort.SortLomuto(array);
            totalComparisonsLomuto += quickSort.Comparisons;
            totalSwapsLomuto += quickSort.Swaps;
            totalTimeLomuto += quickSort.ExecutionTime.TotalMilliseconds;

            // Reset and shuffle array for Hoare
            array = Enumerable.Range(1, n).OrderBy(_ => random.Next(1, n)).ToArray();

            // Sort using Hoare
            quickSort.SortHoare(array);
            totalComparisonsHoare += quickSort.Comparisons;
            totalSwapsHoare += quickSort.Swaps;
            totalTimeHoare += quickSort.ExecutionTime.TotalMilliseconds;
        }

        Console.WriteLine("Lomuto's Quicksort Averages:");
        Console.WriteLine($"Comparisons: {totalComparisonsLomuto / iterations}");
        Console.WriteLine($"Swaps: {totalSwapsLomuto / iterations}");
        Console.WriteLine($"Time (ms): {totalTimeLomuto / iterations}");

        Console.WriteLine("\nHoare's Quicksort Averages:");
        Console.WriteLine($"Comparisons: {totalComparisonsHoare / iterations}");
        Console.WriteLine($"Swaps: {totalSwapsHoare / iterations}");
        Console.WriteLine($"Time (ms): {totalTimeHoare / iterations}");
    }
}

using System.Diagnostics;

namespace LeetCode.Algorithms;

/// <summary>
/// Quick sort algorithms.
/// </summary>
/// <typeparam name="T"> The type of the elements in the array.</typeparam>
public class QuickSort<T> where T : IComparable<T>
{
    private readonly Stopwatch _stopwatch = new();
    
    public int Comparisons { get; private set; }
    public int Swaps { get; private set; }
    public TimeSpan ExecutionTime { get; private set; }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with Hoare's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    public void SortHoare(T[] array)
    {
        Swaps = 0;
        Comparisons = 0;
        _stopwatch.Restart(); // Start the stopwatch to measure the execution time
        
        Sort(array, 0, array.Length - 1, HoarePartition);
        
        _stopwatch.Stop();
        ExecutionTime = _stopwatch.Elapsed;
    }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with Lomuto's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    public void SortLomuto(T[] array)
    {
        Swaps = 0;
        Comparisons = 0;
        _stopwatch.Restart(); // Start the stopwatch to measure the execution time
        
        Sort(array, 0, array.Length - 1, LomutoPartition);
        
        _stopwatch.Stop();
        ExecutionTime = _stopwatch.Elapsed;
    }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with given partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <param name="start">The starting index of the portion of the array to be sorted.</param>
    /// <param name="end">The ending index of the portion of the array to be sorted.</param>
    /// <param name="partition">The partition method</param>
    private void Sort(T[] array, int start, int end, Func<T[], int, int, int> partition)
    {
        if (start >= end)
        {
            return;
        }
        
        // Partition the array and get the pivot index
        var pivotIndex = partition(array, start, end);
        
        // Recursively sort elements starting from the beginning of the array to the pivot index (inclusive)
        // and from the pivot index (exclusive) to the end of the array
        Sort(array, start, pivotIndex - 1, partition);
        Sort(array, pivotIndex + 1, end, partition);
    }

    /// <summary>
    /// Partitions the array using Hoare's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be partitioned.</param>
    /// <param name="start">The starting index of the portion of the array to be partitioned.</param>
    /// <param name="end">The ending index of the portion of the array to be partitioned.</param>
    /// <returns>The index of the pivot element.</returns>
    private int HoarePartition(T[] array, int start, int end)
    {
        var pivot = array[end]; // Choose the last element as the pivot
        var left = start;  // Index of the smaller element
        var right = end; // Index of the larger element

        while (true)
        {
            // Find an element greater than or equal to pivot
            while (array[left].CompareTo(pivot) < 0)
            {
                Comparisons++;
                left++;
            }
            
            // Find an element smaller than or equal to pivot
            while (array[right].CompareTo(pivot) > 0)
            {
                Comparisons++;
                right--;
            }

            // If pointers met, partition is done
            if (left >= right)
            {
                return right;
            }

            // Swap elements at the two pointers
            Swap(array, left, right);
        }
    }
    
    /// <summary>
    /// Partitions the array using Lomuto's partitioning scheme.
    /// </summary>
    /// <param name="array">Input array</param>
    /// <param name="start">The starting index of the portion of the array to be partitioned.</param>
    /// <param name="end">The ending index of the portion of the array to be partitioned.</param>
    /// <returns>The index of the pivot element.</returns>
    private int LomutoPartition(T[] array, int start, int end)
    {
        var pivot = array[end]; // Choose the last element as the pivot
        var i = start - 1; // Index of the smaller element
        
        for (var j = start; j < end; j++)
        {
            Comparisons++;
            
            // If the current element is smaller than the pivot element swap them and increment the index of the smaller element
            if (array[j].CompareTo(pivot) < 0)
            {
                i++;
                Swap(array, i, j);
            }
        }
        
        // Place the pivot element in its correct position
        Swap(array, i + 1, end);
        return i + 1; // Return the index of the pivot element
    }
    
    private void Swap(T[] array, int index1, int index2)
    {
        // No need to swap the same elements
        if (index1 == index2 || array[index1].Equals(array[index2])) 
        {
            return;
        }
        
        Swaps++;
        (array[index1], array[index2]) = (array[index2], array[index1]);
    }
}

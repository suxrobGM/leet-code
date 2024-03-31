using System.Diagnostics;

namespace LeetCode.Algorithms;

/// <summary>
/// Quick sort algorithms.
/// </summary>
public class QuickSort
{
    private readonly Stopwatch _stopwatch = new();
    
    public int Comparisons { get; private set; }
    public int Swaps { get; private set; }
    public TimeSpan ExecutionTime { get; private set; }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with Hoare's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    public void SortHoare(int[] array)
    {
        Swaps = 0;
        Comparisons = 0;
        _stopwatch.Restart(); // Start the stopwatch to measure the execution time
        
        SortHoare(array, 0, array.Length - 1);
        
        _stopwatch.Stop();
        ExecutionTime = _stopwatch.Elapsed;
    }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with Lomuto's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    public void SortLomuto(int[] array)
    {
        Swaps = 0;
        Comparisons = 0;
        _stopwatch.Restart(); // Start the stopwatch to measure the execution time
        
        SortLomuto(array, 0, array.Length - 1);
        
        _stopwatch.Stop();
        ExecutionTime = _stopwatch.Elapsed;
    }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with Hoare's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <param name="start">The starting index of the portion of the array to be sorted.</param>
    /// <param name="end">The ending index of the portion of the array to be sorted.</param>
    private void SortHoare(int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
        
        // Partition the array and get the pivot index
        var pivotIndex = HoarePartition(array, start, end);
        
        // Recursively sort elements starting from the beginning of the array to the pivot index (inclusive)
        // and from the pivot index (exclusive) to the end of the array
        SortHoare(array, start, pivotIndex);
        SortHoare(array, pivotIndex + 1, end);
    }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm with Lomuto's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <param name="start">The starting index of the portion of the array to be sorted.</param>
    /// <param name="end">The ending index of the portion of the array to be sorted.</param>
    private void SortLomuto(int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
        
        // Partition the array and get the pivot index
        var pivotIndex = LomutoPartition(array, start, end);
        
        // Recursively sort elements starting from the beginning of the array to the pivot index (exclusive)
        // and from the pivot index (exclusive) to the end of the array
        SortLomuto(array, start, pivotIndex - 1);
        SortLomuto(array, pivotIndex + 1, end);
    }

    /// <summary>
    /// Partitions the array using Hoare's partitioning scheme.
    /// </summary>
    /// <param name="array">The array to be partitioned.</param>
    /// <param name="start">The starting index of the portion of the array to be partitioned.</param>
    /// <param name="end">The ending index of the portion of the array to be partitioned.</param>
    /// <returns>The index of the pivot element.</returns>
    private int HoarePartition(int[] array, int start, int end)
    {
        var pivot = array[start]; // Choose the first element as the pivot
        var left = start;  // Index of the smaller element
        var right = end; // Index of the larger element

        while (true)
        {
            // Find an element greater than or equal to pivot
            while (array[left] < pivot)
            {
                Comparisons++;
                left++;
            }
            
            // Find an element smaller than or equal to pivot
            while (array[right] > pivot)
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
    private int LomutoPartition(int[] array, int start, int end)
    {
        var pivot = array[end]; // Choose the last element as the pivot
        var i = start - 1; // Index of the smaller element
        
        for (var j = start; j < end; j++)
        {
            Comparisons++;
            
            // If the current element is smaller than the pivot element swap them and increment the index of the smaller element
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }
        
        // Place the pivot element in its correct position
        Swap(array, i + 1, end);
        return i + 1; // Return the index of the pivot element
    }
    
    private void Swap(int[] array, int index1, int index2)
    {
        // No need to swap the same elements
        if (index1 == index2 || array[index1] == array[index2]) 
        {
            return;
        }
        
        Swaps++;
        (array[index1], array[index2]) = (array[index2], array[index1]);
    }
}

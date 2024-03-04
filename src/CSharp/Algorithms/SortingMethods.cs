namespace LeetCode.Algorithms;

/// <summary>
/// Sorting algorithms.
/// </summary>
public static class SortingMethods
{
    /// <summary>
    /// Sorts an array using the QuickSort algorithm.
    /// </summary>
    /// <param name="arr">The array to be sorted.</param>
    public static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }
    
    /// <summary>
    /// Sorts an array using the QuickSort algorithm.
    /// </summary>
    /// <param name="arr">The array to be sorted.</param>
    /// <param name="start">The starting index of the portion of the array to be sorted.</param>
    /// <param name="end">The ending index of the portion of the array to be sorted.</param>
    public static void QuickSort(int[] arr, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
    
        // Partition the array and get the pivot index
        var pivotIndex = HoarePartition(arr, start, end);

        // Recursively sort elements before and after pivot
        QuickSort(arr, start, pivotIndex);
        QuickSort(arr, pivotIndex + 1, end);
    }

    /// <summary>
    /// Partitions the array using Hoare's partitioning scheme.
    /// </summary>
    /// <param name="arr">The array to be partitioned.</param>
    /// <param name="start">The starting index of the portion of the array to be partitioned.</param>
    /// <param name="end">The ending index of the portion of the array to be partitioned.</param>
    /// <returns>The index of the pivot element.</returns>
    private static int HoarePartition(int[] arr, int start, int end)
    {
        var pivot = arr[end];
        var left = start - 1;
        var right = end + 1;

        while (true)
        {
            // Find an element greater than or equal to pivot
            do
            {
                left++;
            } while (arr[left] < pivot);

            // Find an element smaller than or equal to pivot
            do
            {
                right--;
            } while (arr[right] > pivot);

            // If pointers met, partition is done
            if (left >= right)
            {
                return right;
            }

            // Swap elements at the two pointers
            (arr[left], arr[right]) = (arr[right], arr[left]);
        }
    }
}

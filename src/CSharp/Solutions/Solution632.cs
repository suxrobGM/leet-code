using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution632
{
    /// <summary>
    /// 632. Smallest Range Covering Elements from K Lists - Hard
    /// <a href="https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists">See the problem</a>
    /// </summary>
    public int[] SmallestRange(IList<IList<int>> nums)
    {
        // Min heap to store (value, row_index, col_index)
        var minHeap = new PriorityQueue<(int, int, int), int>();
        var currentMax = int.MinValue;

        // Initialize the heap with the first element of each list
        for (var i = 0; i < nums.Count; i++)
        {
            var val = nums[i][0];
            minHeap.Enqueue((val, i, 0), val);
            currentMax = Math.Max(currentMax, val); // Track the maximum value
        }

        // Result range variables
        int start = int.MinValue, end = int.MaxValue;

        // Continue until we can no longer process the elements
        while (minHeap.Count == nums.Count)
        {
            // Ensure all lists are represented
            var (minVal, row, col) = minHeap.Dequeue(); // Get the smallest value

            // Check if we found a smaller range
            if (currentMax - minVal < end - start || (currentMax - minVal == end - start && minVal < start))
            {
                start = minVal;
                end = currentMax;
            }

            // If there are more elements in the current list, add the next one
            if (col + 1 < nums[row].Count)
            {
                var nextVal = nums[row][col + 1];
                minHeap.Enqueue((nextVal, row, col + 1), nextVal);
                currentMax = Math.Max(currentMax, nextVal); // Update the current max
            }
        }

        return [start, end];
    }
}

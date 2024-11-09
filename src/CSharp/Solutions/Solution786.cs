using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution786
{
    /// <summary>
    /// 786. K-th Smallest Prime Fraction - Medium
    /// <a href="https://leetcode.com/problems/k-th-smallest-prime-fraction">See the problem</a>
    /// </summary>
    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
        var n = arr.Length;
        var minHeap = new PriorityQueue<(double value, int i, int j), double>();

        // Initialize the heap with the smallest fractions
        for (var i = 0; i < n - 1; i++)
        {
            minHeap.Enqueue((arr[i] / (double)arr[n - 1], i, n - 1), arr[i] / (double)arr[n - 1]);
        }

        // Extract the smallest fraction k times
        for (var count = 0; count < k - 1; count++)
        {
            var (value, i, j) = minHeap.Dequeue();
            if (j - 1 > i)
            {
                minHeap.Enqueue((arr[i] / (double)arr[j - 1], i, j - 1), arr[i] / (double)arr[j - 1]);
            }
        }

        var (resultValue, resultI, resultJ) = minHeap.Dequeue();
        return [arr[resultI], arr[resultJ]];
    }
}

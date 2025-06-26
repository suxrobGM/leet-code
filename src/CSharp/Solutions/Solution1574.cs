using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1574
{
    /// <summary>
    /// 1574. Shortest Subarray to be Removed to Make Array Sorted - Medium
    /// <a href="https://leetcode.com/problems/shortest-subarray-to-be-removed-to-make-array-sorted">See the problem</a>
    /// </summary>
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        int n = arr.Length;
        if (n <= 1) return 0;

        // Find the longest non-decreasing prefix
        int left = 0;
        while (left < n - 1 && arr[left] <= arr[left + 1])
        {
            left++;
        }

        // If the entire array is non-decreasing
        if (left == n - 1) return 0;

        // Find the longest non-decreasing suffix
        int right = n - 1;
        while (right > 0 && arr[right - 1] <= arr[right])
        {
            right--;
        }

        // If we remove the entire suffix
        int minLength = right;

        // Try to find the minimum length by removing a subarray
        for (int i = 0; i <= left; i++)
        {
            while (right < n && arr[i] > arr[right])
            {
                right++;
            }
            minLength = Math.Min(minLength, right - i - 1);
        }

        return minLength;
    }
}

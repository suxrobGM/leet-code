using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1588
{
    /// <summary>
    /// 1588. Sum of All Odd Length Subarrays - Easy
    /// <a href="https://leetcode.com/problems/sum-of-all-odd-length-subarrays">See the problem</a>
    /// </summary>
    public int SumOddLengthSubarrays(int[] arr)
    {
        int totalSum = 0;
        int n = arr.Length;

        // Iterate over all possible starting points
        for (int start = 0; start < n; start++)
        {
            // Iterate over all possible odd lengths
            for (int length = 1; start + length <= n; length += 2)
            {
                // Calculate the sum of the subarray
                for (int i = start; i < start + length; i++)
                {
                    totalSum += arr[i];
                }
            }
        }

        return totalSum;
    }
}

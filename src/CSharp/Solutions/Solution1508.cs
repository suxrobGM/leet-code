using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1508
{
    /// <summary>
    /// 1508. Range Sum of Sorted Subarray Sums - Medium
    /// <a href="https://leetcode.com/problems/range-sum-of-sorted-subarray-sums">See the problem</a>
    /// </summary>
    public int RangeSum(int[] nums, int n, int left, int right)
    {
        // Step 1: Generate all subarray sums
        var subarraySums = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = i; j < n; j++)
            {
                sum += nums[j];
                subarraySums.Add(sum);
            }
        }

        // Step 2: Sort the subarray sums
        subarraySums.Sort();

        // Step 3: Calculate the range sum from left to right
        long result = 0;
        for (int i = left - 1; i < right; i++)
        {
            result += subarraySums[i];
        }

        // Step 4: Return the result modulo 10^9 + 7
        return (int)(result % (1_000_000_007));
    }
}

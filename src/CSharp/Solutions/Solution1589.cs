using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1589
{
    /// <summary>
    /// 1589. Maximum Sum Obtained of Any Permutation - Medium
    /// <a href="https://leetcode.com/problems/maximum-sum-obtained-of-any-permutation">See the problem</a>
    /// </summary>
    public int MaxSumRangeQuery(int[] nums, int[][] requests)
    {
        int n = nums.Length;
        int[] count = new int[n];

        // Count the number of times each index is requested
        foreach (var request in requests)
        {
            int start = request[0];
            int end = request[1];
            count[start]++;
            if (end + 1 < n) count[end + 1]--;
        }

        // Calculate the prefix sum to get the actual counts
        for (int i = 1; i < n; i++)
        {
            count[i] += count[i - 1];
        }

        // Sort nums and counts in descending order
        Array.Sort(nums);
        Array.Sort(count);

        long result = 0;
        const int MOD = 1000000007;

        // Calculate the maximum sum using the sorted arrays
        for (int i = 0; i < n; i++)
        {
            result = (result + (long)nums[i] * count[i]) % MOD;
        }

        return (int)result;
    }
}

using System.Text;

namespace LeetCode.Solutions;

public class Solution416
{
    /// <summary>
    /// 416. Partition Equal Subset Sum - Medium
    /// <a href="https://leetcode.com/problems/partition-equal-subset-sum">See the problem</a>
    /// </summary>
    public bool CanPartition(int[] nums)
    {
        var sum = 0;

        foreach (var num in nums)
        {
            sum += num;
        }

        if (sum % 2 != 0)
        {
            return false;
        }

        sum /= 2;

        var dp = new bool[sum + 1];
        dp[0] = true;

        foreach (var num in nums)
        {
            for (var i = sum; i >= num; i--)
            {
                dp[i] = dp[i] || dp[i - num];
            }
        }

        return dp[sum];
    }
}

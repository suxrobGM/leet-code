namespace LeetCode.Solutions;

public class Solution494
{
    /// <summary>
    /// 494. Target Sum - Medium
    /// <a href="https://leetcode.com/problems/target-sum">See the problem</a>
    /// </summary>
    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }

        // If (target + sum) is odd or target is out of the feasible range
        if ((target + sum) % 2 != 0 || sum < Math.Abs(target))
        {
            return 0;
        }

        int subsetSum = (target + sum) / 2;

        // DP array initialization
        int[] dp = new int[subsetSum + 1];
        dp[0] = 1;  // There is one way to achieve sum 0: by choosing no elements

        // DP transition
        foreach (int num in nums)
        {
            for (int j = subsetSum; j >= num; j--)
            {
                dp[j] += dp[j - num];
            }
        }

        return dp[subsetSum];
    }
}

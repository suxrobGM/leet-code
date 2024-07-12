namespace LeetCode.Solutions;

public class Solution368
{
    /// <summary>
    /// 368. Largest Divisible Subset - Medium
    /// <a href="https://leetcode.com/problems/largest-divisible-subset">See the problem</a>
    /// </summary>
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);

        var dp = new int[nums.Length];
        var prev = new int[nums.Length];
        var max = 0;
        var maxIndex = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            prev[i] = -1;

            for (var j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && dp[i] < dp[j] + 1)
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }

            if (dp[i] > max)
            {
                max = dp[i];
                maxIndex = i;
            }
        }

        var result = new List<int>();

        while (maxIndex != -1)
        {
            result.Add(nums[maxIndex]);
            maxIndex = prev[maxIndex];
        }

        return result;
    }
}

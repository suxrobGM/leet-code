using System.Text;

namespace LeetCode.Solutions;

public class Solution805
{
    /// <summary>
    /// 805. Split Array With Same Average - Hard
    /// <a href="https://leetcode.com/problems/split-array-with-same-average">See the problem</a>
    /// </summary>
    public bool SplitArraySameAverage(int[] nums)
    {
        var n = nums.Length;
        var sum = nums.Sum();
        var dp = new HashSet<int>[n / 2 + 1];

        for (var i = 0; i < dp.Length; i++)
        {
            dp[i] = new HashSet<int>();
        }

        dp[0].Add(0);

        foreach (var num in nums)
        {
            for (var i = dp.Length - 1; i >= 1; i--)
            {
                foreach (var prev in dp[i - 1])
                {
                    dp[i].Add(prev + num);
                }
            }
        }

        for (var i = 1; i < dp.Length; i++)
        {
            if (sum * i % n == 0 && dp[i].Contains(sum * i / n))
            {
                return true;
            }
        }

        return false;
    }
}

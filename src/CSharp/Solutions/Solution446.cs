using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution446
{
    /// <summary>
    /// 446. Arithmetic Slices II - Subsequence - Hard
    /// <a href="https://leetcode.com/problems/arithmetic-slices-ii-subsequence">See the problem</a>
    /// </summary>
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var n = nums.Length;
        var result = 0;
        var dp = new Dictionary<int, int>[n];

        for (var i = 0; i < n; i++)
        {
            dp[i] = new Dictionary<int, int>();

            for (var j = 0; j < i; j++)
            {
                var diff = (long)nums[i] - nums[j];

                if (diff < int.MinValue || diff > int.MaxValue)
                {
                    continue;
                }

                var d = (int)diff;
                var count = dp[j].ContainsKey(d) ? dp[j][d] : 0;

                dp[i][d] = dp[i].ContainsKey(d) ? dp[i][d] + count + 1 : count + 1;
                result += count;
            }
        }

        return result;
    }
}

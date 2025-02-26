using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1027
{
    /// <summary>
    /// 1027. Longest Arithmetic Subsequence - Medium
    /// <a href="https://leetcode.com/problems/longest-arithmetic-subsequence</a>
    /// </summary>
    public int LongestArithSeqLength(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) {
            return n;
        }

        var dp = new Dictionary<int, int>[n];
        int maxLength = 2;

        for (int i = 0; i < n; i++)
        {
            dp[i] = [];

            for (int j = 0; j < i; j++)
            {
                int diff = nums[i] - nums[j];

                if (dp[j].ContainsKey(diff))
                {
                    dp[i][diff] = dp[j][diff] + 1;
                }
                else
                {
                    dp[i][diff] = 2; // Start new sequence with nums[j] and nums[i]
                }

                maxLength = Math.Max(maxLength, dp[i][diff]);
            }
        }

        return maxLength;
    }
}

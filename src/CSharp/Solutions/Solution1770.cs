using System.Text;

namespace LeetCode.Solutions;

public class Solution1770
{
    /// <summary>
    /// 1770. Maximum Score from Performing Multiplication Operations - Hard
    /// <a href="https://leetcode.com/problems/maximum-score-from-performing-multiplication-operations">See the problem</a>
    /// </summary>
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        int n = nums.Length, m = multipliers.Length;

        // dpNext[l] = dp[i+1][l], dpCur[l] = dp[i][l]
        var dpNext = new int[m + 1];
        var dpCur = new int[m + 1];

        for (int i = m - 1; i >= 0; i--)
        {
            int mult = multipliers[i];
            // l can range from 0..i (you cannot have taken more left picks than operations)
            for (int l = i; l >= 0; l--)
            {
                int rIndex = n - 1 - (i - l); // how many taken from right so far = i - l
                int takeLeft = mult * nums[l] + dpNext[l + 1];
                int takeRight = mult * nums[rIndex] + dpNext[l];
                dpCur[l] = Math.Max(takeLeft, takeRight);
            }
            // roll the row
            var tmp = dpNext; dpNext = dpCur; dpCur = tmp;
        }

        return dpNext[0];
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1335
{
    /// <summary>
    /// 1335. Minimum Difficulty of a Job Schedule - Hard
    /// <a href="https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule">See the problem</a>
    /// </summary>
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        int n = jobDifficulty.Length;
        if (n < d) return -1;

        var dp = new int[d + 1, n + 1];

        for (int i = 0; i <= d; i++)
            for (int j = 0; j <= n; j++)
                dp[i, j] = int.MaxValue / 2; // avoid overflow

        dp[0, 0] = 0;

        for (int day = 1; day <= d; day++)
        {
            for (int j = day; j <= n; j++)
            {
                int max = 0;
                for (int k = j - 1; k >= day - 1; k--)
                {
                    max = Math.Max(max, jobDifficulty[k]);
                    dp[day, j] = Math.Min(dp[day, j], dp[day - 1, k] + max);
                }
            }
        }

        return dp[d, n];
    }
}

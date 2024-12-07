using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution871
{
    /// <summary>
    /// 871. Minimum Number of Refueling Stops - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-refueling-stops">See the problem</a>
    /// </summary>
    public int MinRefuelStops(int target, int startFuel, int[][] stations)
    {
        var n = stations.Length;
        var dp = new long[n + 1];
        dp[0] = startFuel;

        for (int i = 0; i < n; i++)
        {
            for (int t = i; t >= 0; t--)
            {
                if (dp[t] >= stations[i][0])
                {
                    dp[t + 1] = Math.Max(dp[t + 1], dp[t] + stations[i][1]);
                }
            }
        }

        for (int i = 0; i <= n; i++)
        {
            if (dp[i] >= target)
            {
                return i;
            }
        }

        return -1;
    }
}

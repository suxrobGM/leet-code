using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1883
{
    /// <summary>
    /// 1883. Minimum Skips to Arrive at Meeting On Time - Hard
    /// <a href="https://leetcode.com/problems/minimum-skips-to-arrive-at-meeting-on-time">See the problem</a>
    /// </summary>
    public int MinSkips(int[] dist, int speed, int hoursBefore)
    {
        int n = dist.Length;
        long INF = (long)1e18;

        // dp[j] = minimal total (time * speed) after processing i roads, using j skips
        var dp = new long[n + 1];
        for (int j = 1; j <= n; j++) dp[j] = INF; // dp[0]=0

        for (int i = 0; i < n; i++)
        {
            var ndp = new long[n + 1];
            for (int j = 0; j <= n; j++) ndp[j] = INF;

            for (int j = 0; j <= i; j++)
            {
                if (dp[j] >= INF) continue;

                long withoutSkip = dp[j] + dist[i];
                if (i < n - 1)
                {
                    // must wait to next integer hour: round up to multiple of speed
                    withoutSkip = CeilToMultiple(withoutSkip, speed);
                }
                ndp[j] = Math.Min(ndp[j], withoutSkip);

                // use a skip here (no rounding)
                ndp[j + 1] = Math.Min(ndp[j + 1], dp[j] + dist[i]);
            }

            dp = ndp;
        }

        long limit = (long)hoursBefore * speed;
        for (int j = 0; j <= n; j++)
        {
            if (dp[j] <= limit) return j;
        }
        return -1;
    }

    private static long CeilToMultiple(long x, int m)
    {
        long r = x % m;
        return r == 0 ? x : x + (m - r);
    }
}

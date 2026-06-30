namespace LeetCode.Solutions;

public class Solution2188
{
    /// <summary>
    /// 2188. Minimum Time to Finish the Race - Hard
    /// <a href="https://leetcode.com/problems/minimum-time-to-finish-the-race">See the problem</a>
    /// </summary>
    public int MinimumFinishTime(int[][] tires, int changeTime, int numLaps)
    {
        // best[j] = minimum time to run j consecutive laps on a single tire (no change).
        // Since r >= 2, lap time grows exponentially, so a single tire is rarely worth
        // more than ~18 laps before a fresh tire (changeTime + f) becomes cheaper.
        int maxLaps = Math.Min(numLaps, 18);
        long[] best = new long[maxLaps + 1];
        Array.Fill(best, long.MaxValue);

        foreach (var tire in tires)
        {
            long f = tire[0];
            long r = tire[1];
            long lapTime = f;
            long total = 0;

            for (int j = 1; j <= maxLaps; j++)
            {
                total += lapTime;
                best[j] = Math.Min(best[j], total);
                lapTime *= r;

                // Once a single lap exceeds the cost of changing to a fresh tire, stop.
                if (lapTime > changeTime + f)
                {
                    break;
                }
            }
        }

        // dp[i] = minimum time to finish i laps. dp[0] = -changeTime so the very first
        // segment is not charged a tire change.
        long[] dp = new long[numLaps + 1];
        Array.Fill(dp, long.MaxValue);
        dp[0] = -changeTime;

        for (int i = 1; i <= numLaps; i++)
        {
            for (int j = 1; j <= Math.Min(i, maxLaps); j++)
            {
                if (best[j] != long.MaxValue && dp[i - j] != long.MaxValue)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j] + changeTime + best[j]);
                }
            }
        }

        return (int)dp[numLaps];
    }
}

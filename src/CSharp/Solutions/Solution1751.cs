using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1751
{
    /// <summary>
    /// 1751. Maximum Number of Events That Can Be Attended II - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended-ii">See the problem</a>
    /// </summary>
    public int MaxValue(int[][] events, int k)
    {
        int n = events.Length;

        // Sort by end time
        Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));

        // Precompute last non-overlapping event index for each event
        var prev = new int[n];
        for (int i = 0; i < n; i++)
        {
            int lo = 0, hi = i - 1, ans = -1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (events[mid][1] < events[i][0])
                { // non-overlapping
                    ans = mid;
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            prev[i] = ans;
        }

        // DP array: dp[j][i] = max value using first i events and at most j picks
        var dp = new int[k + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            int val = events[i - 1][2];
            for (int j = 1; j <= k; j++)
            {
                // Option 1: skip event i
                dp[j, i] = dp[j, i - 1];

                // Option 2: take event i
                int take = val;
                if (prev[i - 1] != -1)
                {
                    take += dp[j - 1, prev[i - 1] + 1];
                }
                else if (j - 1 == 0)
                {
                    take = val; // only this event
                }
                else
                {
                    take = Math.Max(take, val);
                }

                dp[j, i] = Math.Max(dp[j, i], take);
            }
        }

        return dp[k, n];
    }
}


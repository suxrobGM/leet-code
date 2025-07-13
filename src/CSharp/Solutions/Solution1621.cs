using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1621
{
    /// <summary>
    /// 1621. Number of Sets of K Non-Overlapping Line Segments - Medium
    /// <a href="https://leetcode.com/problems/number-of-sets-of-k-non-overlapping-line-segments">See the problem</a>
    /// </summary>
    public int NumberOfSets(int n, int k)
    {
        const int MOD = 1_000_000_007;
        var dp = new int[n, k + 1];
        var pref = new int[n, k + 1];     // prefix sums of dp

        // base: 0 segments
        for (int i = 0; i < n; ++i)
        {
            dp[i, 0] = 1;
            pref[i, 0] = i + 1;            // sum_{t=0..i} dp[t,0] = i+1
        }

        // cannot draw segments with only one point
        for (int j = 1; j <= k; ++j)
            pref[0, j] = 0;

        for (int i = 1; i < n; ++i)
        {
            for (int j = 1; j <= k; ++j)
            {
                long ways = dp[i - 1, j];          // case 1
                ways += pref[i - 1, j - 1];        // case 2
                dp[i, j] = (int)(ways % MOD);
            }

            // update prefix sums for this row
            for (int j = 1; j <= k; ++j)
            {
                long sum = pref[i - 1, j] + dp[i, j];
                pref[i, j] = (int)(sum % MOD);
            }
        }

        return dp[n - 1, k];
    }
}

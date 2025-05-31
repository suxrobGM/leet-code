using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1494
{
    /// <summary>
    /// 1494. Parallel Courses II - Hard
    /// <a href="https://leetcode.com/problems/parallel-courses-ii">See the problem</a>
    /// </summary>
    public int MinNumberOfSemesters(int n, int[][] relations, int k)
    {
        var pre = new int[n];
        foreach (var rel in relations)
        {
            int u = rel[0] - 1, v = rel[1] - 1;
            pre[v] |= 1 << u;
        }

        var size = 1 << n;
        var dp = new int[size];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int mask = 0; mask < size; mask++)
        {
            if (dp[mask] == int.MaxValue) continue;

            // Find courses that are available now (all prerequisites satisfied)
            int canTake = 0;
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) == 0 && (mask & pre[i]) == pre[i])
                {
                    canTake |= 1 << i;
                }
            }

            // Enumerate all subsets of canTake with <= k bits
            for (int sub = canTake; sub > 0; sub = (sub - 1) & canTake)
            {
                if (CountBits(sub) <= k)
                {
                    int nextMask = mask | sub;
                    dp[nextMask] = Math.Min(dp[nextMask], dp[mask] + 1);
                }
            }

            // Special case: if available courses ≤ k, take all
            if (CountBits(canTake) <= k)
            {
                int nextMask = mask | canTake;
                dp[nextMask] = Math.Min(dp[nextMask], dp[mask] + 1);
            }
        }

        return dp[size - 1];
    }

    private int CountBits(int x)
    {
        int count = 0;
        while (x > 0)
        {
            x &= x - 1;
            count++;
        }
        return count;
    }
}

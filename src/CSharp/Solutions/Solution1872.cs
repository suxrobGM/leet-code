using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1872
{
    /// <summary>
    /// 1872. Stone Game VIII - Hard
    /// <a href="https://leetcode.com/problems/stone-game-viii">See the problem</a>
    /// </summary>
    public int StoneGameVIII(int[] stones)
    {
        int n = stones.Length;
        long[] pref = new long[n];
        pref[0] = stones[0];
        for (int i = 1; i < n; i++) pref[i] = pref[i - 1] + stones[i];

        long best = pref[n - 1];              // base: take all at once
        for (int i = n - 2; i >= 1; i--)      // i from n-2 down to 1
        {
            // either keep previous best, or split at i and let opponent face 'best'
            best = Math.Max(best, pref[i] - best);
        }
        return (int)best;
    }
}

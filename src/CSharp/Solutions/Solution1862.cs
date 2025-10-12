using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1862
{
    /// <summary>
    /// 1862. Sum of Floored Pairs - Hard
    /// <a href="https://leetcode.com/problems/sum-of-floored-pairs">See the problem</a>
    /// </summary>
    public int SumOfFlooredPairs(int[] nums)
    {
        const int MOD = 1_000_000_007;

        int maxA = 0;
        foreach (var v in nums) if (v > maxA) maxA = v;

        // Frequency of each value
        var cnt = new int[maxA + 1];
        foreach (var v in nums) cnt[v]++;

        // Prefix counts: pref[i] = count of numbers <= i
        var pref = new int[maxA + 1];
        for (int i = 1; i <= maxA; i++)
            pref[i] = pref[i - 1] + cnt[i];

        long ans = 0;

        for (int x = 1; x <= maxA; x++)
        {
            int cX = cnt[x];
            if (cX == 0) continue;

            // For each k where k*x <= maxA, count numbers in [k*x, (k+1)*x - 1]
            for (int k = 1; k <= maxA / x; k++)
            {
                int l = k * x;
                int r = Math.Min((k + 1) * x - 1, maxA);
                int countInBucket = pref[r] - pref[l - 1];
                if (countInBucket == 0) continue;

                long add = (long)cX * k % MOD * countInBucket % MOD;
                ans += add;
                if (ans >= MOD) ans -= MOD;
            }
        }

        return (int)(ans % MOD);
    }
}

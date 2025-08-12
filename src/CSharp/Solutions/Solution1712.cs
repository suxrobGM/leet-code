using System.Text;


namespace LeetCode.Solutions;

public class Solution1712
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1712. Ways to Split Array Into Three Subarrays - Medium
    /// <a href="https://leetcode.com/problems/ways-to-split-array-into-three-subarrays">See the problem</a>
    /// </summary>
    public int WaysToSplit(int[] nums)
    {
        int n = nums.Length;
        long[] pre = new long[n + 1];
        for (int i = 0; i < n; i++) pre[i + 1] = pre[i] + nums[i];

        long ans = 0;

        for (int i = 1; i <= n - 2; i++)
        {
            long leftSum = pre[i];

            // Find first j in [i+1, n-1] with pre[j] >= 2*leftSum
            int lo = LowerBound(pre, i + 1, n - 1, 2 * leftSum);
            if (lo == -1) continue; // no feasible middle

            // Find last j in [i+1, n-1] with pre[j] <= (pre[n] + leftSum)/2
            long maxMid = (pre[n] + leftSum) / 2;
            int hi = UpperBoundInclusive(pre, i + 1, n - 1, maxMid);
            if (hi == -1) continue;

            if (lo <= hi)
            {
                ans += (hi - lo + 1);
                if (ans >= MOD) ans %= MOD;
            }
        }

        return (int)(ans % MOD);
    }

    // first index in [l..r] with a[idx] >= target; -1 if none
    private int LowerBound(long[] a, int l, int r, long target)
    {
        int res = -1;
        while (l <= r)
        {
            int m = l + ((r - l) >> 1);
            if (a[m] >= target) { res = m; r = m - 1; }
            else l = m + 1;
        }
        return res;
    }

    // last index in [l..r] with a[idx] <= target; -1 if none
    private int UpperBoundInclusive(long[] a, int l, int r, long target)
    {
        int res = -1;
        while (l <= r)
        {
            int m = l + ((r - l) >> 1);
            if (a[m] <= target) { res = m; l = m + 1; }
            else r = m - 1;
        }
        return res;
    }
}

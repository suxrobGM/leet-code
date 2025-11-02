using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1889
{
    /// <summary>
    /// 1889. Minimum Space Wasted From Packaging - Hard
    /// <a href="https://leetcode.com/problems/minimum-space-wasted-from-packaging">See the problem</a>
    /// </summary>
    public int MinWastedSpace(int[] packages, int[][] boxes)
    {
        const long MOD = 1_000_000_007L;

        Array.Sort(packages);
        int n = packages.Length;

        // prefix sums of packages (long to avoid overflow)
        var pref = new long[n + 1];
        for (int i = 0; i < n; i++) pref[i + 1] = pref[i] + packages[i];

        long totalPackages = pref[n];
        long best = long.MaxValue;

        foreach (var supplier in boxes)
        {
            Array.Sort(supplier);
            if (supplier[^1] < packages[^1]) continue; // cannot fit the largest package

            long usedBoxSum = 0;
            int prev = 0;

            foreach (int b in supplier)
            {
                // index of first package > b
                int idx = UpperBound(packages, b);
                if (idx <= prev) continue;

                int cnt = idx - prev;
                long sumPkg = pref[idx] - pref[prev];
                usedBoxSum += (long)b * cnt - sumPkg;
                prev = idx;
                if (prev == n) break;
            }

            if (prev == n)
                best = Math.Min(best, usedBoxSum);
        }

        if (best == long.MaxValue) return -1;
        return (int)(best % MOD);
    }

    // first index i such that arr[i] > val
    private int UpperBound(int[] arr, int val)
    {
        int l = 0, r = arr.Length;
        while (l < r)
        {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] <= val) l = mid + 1;
            else r = mid;
        }
        return l;
    }
}

using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1739
{
    /// <summary>
    /// 1739. Building Boxes - Hard
    /// <a href="https://leetcode.com/problems/building-boxes">See the problem</a>
    /// </summary>
    public int MinimumBoxes(int n)
    {
        long N = n;

        // find largest k with T(k) <= N
        int lo = 0, hi = 200000;
        while (lo < hi)
        {
            int mid = (lo + hi + 1) >> 1;
            if (Tetra(mid) <= N) lo = mid; else hi = mid - 1;
        }
        int k = lo;

        long baseFloor = Tri(k);
        long used = Tetra(k);
        long r = N - used;
        if (r == 0) return (int)baseFloor;

        // minimal t with t*(t+1)/2 >= r
        int t = MinTForR(r);
        return (int)(baseFloor + t);
    }

    private long Tri(long k) => k * (k + 1) / 2;
    private long Tetra(long k) => k * (k + 1) * (k + 2) / 6;

    private int MinTForR(long r)
    {
        int lo = 0, hi = 200000;
        while (lo < hi)
        {
            int mid = (lo + hi) >> 1;
            long cap = (long)mid * (mid + 1) / 2;
            if (cap >= r) hi = mid;
            else lo = mid + 1;
        }
        return lo;
    }
}


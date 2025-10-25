using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1879
{
    /// <summary>
    /// 1879. Get Biggest Three Rhombus Sums in a Grid - Medium
    /// <a href="https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid">See the problem</a>
    /// </summary>
    public int MinimumXORSum(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int size = 1 << n;
        const int INF = int.MaxValue / 2;
        var dp = new int[size];
        Array.Fill(dp, INF);
        dp[0] = 0;

        for (int mask = 1; mask < size; mask++)
        {
            int i = CountBits(mask) - 1; // index in nums1
            for (int j = 0; j < n; j++)
            {
                if ((mask & (1 << j)) == 0) continue;
                int prev = mask ^ (1 << j);
                int val = dp[prev] + (nums1[i] ^ nums2[j]);
                if (val < dp[mask]) dp[mask] = val;
            }
        }

        return dp[size - 1];
    }

    private int CountBits(int x)
    {
        int c = 0;
        while (x != 0) { x &= x - 1; c++; }
        return c;
    }
}

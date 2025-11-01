using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1888
{
    /// <summary>
    /// 1888. Minimum Number of Flips to Make the Binary String Alternating - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating">See the problem</a>
    /// </summary>
    public int MinFlips(string s)
    {
        int n = s.Length;
        if (n == 1) return 0;

        string ss = s + s; // consider all rotations as windows in ss
        int m = ss.Length;

        // pref0[i] = #mismatches with pattern "0101..." in ss[0..i-1]
        // pref1[i] = #mismatches with pattern "1010..." in ss[0..i-1]
        var pref0 = new int[m + 1];
        var pref1 = new int[m + 1];

        for (int i = 0; i < m; i++)
        {
            char expect0 = (i % 2 == 0) ? '0' : '1';
            char expect1 = (i % 2 == 0) ? '1' : '0';
            pref0[i + 1] = pref0[i] + (ss[i] != expect0 ? 1 : 0);
            pref1[i + 1] = pref1[i] + (ss[i] != expect1 ? 1 : 0);
        }

        int ans = n; // upper bound

        for (int l = 0; l < n; l++)
        {
            int r = l + n;
            int mis0 = pref0[r] - pref0[l];
            int mis1 = pref1[r] - pref1[l];
            ans = Math.Min(ans, Math.Min(mis0, mis1));
        }

        return ans;
    }
}

using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1849
{
    /// <summary>
    /// 1849. Splitting a String Into Descending Consecutive Values - Medium
    /// <a href="https://leetcode.com/problems/splitting-a-string-into-descending-consecutive-values">See the problem</a>
    /// </summary>
    public bool SplitString(string s)
    {
        int n = s.Length;
        // First piece must leave at least one char for the next piece
        for (int len = 1; len < n; len++)
        {
            BigInteger first = ParseBig(s, 0, len);
            if (Dfs(s, len, first, 1)) return true;
        }
        return false;
    }

    private bool Dfs(string s, int idx, BigInteger prev, int count)
    {
        if (idx == s.Length) return count >= 2;

        BigInteger target = prev - 1;
        // Try all possible next splits starting at idx
        // Stop early if value gets too large and no leading zero to keep trying
        for (int end = idx + 1; end <= s.Length; end++)
        {
            BigInteger val = ParseBig(s, idx, end - idx);

            if (val == target)
            {
                if (Dfs(s, end, val, count + 1)) return true;
                // continue searching (there could be another split with extra leading zeros)
            }

            // Prune: if current starts with non-zero and already > target,
            // making it longer will only increase it further.
            if (val > target && s[idx] != '0') break;
        }

        return false;
    }

    private static BigInteger ParseBig(string s, int start, int length)
    {
        // Substring is small (<= 20), Parse is fine
        return BigInteger.Parse(s.AsSpan(start, length));
    }
}

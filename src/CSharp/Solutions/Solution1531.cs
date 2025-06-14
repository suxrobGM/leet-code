using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1531
{
    private readonly Dictionary<(int, char, int, int), int> memo = [];

    /// <summary>
    /// 1531. String Compression II - Hard
    /// <a href="https://leetcode.com/problems/string-compression-ii">See the problem</a>
    /// </summary>
    public int GetLengthOfOptimalCompression(string s, int k)
    {
        return DP(s, 0, '#', 0, k);
    }

    private int DP(string s, int i, char prev, int count, int k)
    {
        if (k < 0) return int.MaxValue / 2; // invalid
        if (i == s.Length) return 0;

        var key = (i, prev, count, k);
        if (memo.ContainsKey(key)) return memo[key];

        // Option 1: Delete current character
        int res = DP(s, i + 1, prev, count, k - 1);

        // Option 2: Keep current character
        if (s[i] == prev)
        {
            int add = (count == 1 || count == 9 || count == 99) ? 1 : 0;
            res = Math.Min(res, add + DP(s, i + 1, prev, count + 1, k));
        }
        else
        {
            res = Math.Min(res, 1 + DP(s, i + 1, s[i], 1, k));
        }

        return memo[key] = res;
    }
}

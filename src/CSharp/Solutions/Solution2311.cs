using System.Text;

namespace LeetCode.Solutions;

public class Solution2311
{
    /// <summary>
    /// 2311. Longest Binary Subsequence Less Than or Equal to K - Medium
    /// <a href="https://leetcode.com/problems/longest-binary-subsequence-less-than-or-equal-to-k">See the problem</a>
    /// </summary>
    public int LongestSubsequence(string s, int k)
    {
        var count = 0;
        long value = 0;
        long power = 1;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '0')
            {
                count++;
            }
            else if (value + power <= k)
            {
                value += power;
                count++;
            }

            if (power <= k)
            {
                power <<= 1;
            }
        }

        return count;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1312
{
    /// <summary>
    /// 1312. Minimum Insertion Steps to Make a String Palindrome - Hard
    /// <a href="https://leetcode.com/problems/minimum-insertion-steps-to-make-a-string-palindrome">See the problem</a>
    /// </summary>
    public int MinInsertions(string s)
    {
        int n = s.Length;
        var dp = new int[n, n];

        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i < n - len + 1; i++)
            {
                int j = i + len - 1;
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i, j - 1]) + 1;
                }
            }
        }

        return dp[0, n - 1];
    }
}

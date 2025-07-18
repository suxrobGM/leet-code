using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1639
{
    /// <summary>
    /// 1639. Number of Ways to Form a Target String Given a Dictionary - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-to-form-a-target-string-given-a-dictionary">See the problem</a>
    /// </summary>
    public int NumWays(string[] words, string target)
    {
        int mod = 1_000_000_007;
        int m = words[0].Length;
        int n = target.Length;

        // Step 1: Count frequency of each character in each column
        int[,] freq = new int[m, 26];
        foreach (var word in words)
        {
            for (int i = 0; i < m; i++)
                freq[i, word[i] - 'a']++;
        }

        // Step 2: Dynamic Programming
        long[] dp = new long[n + 1];
        dp[0] = 1;

        for (int col = 0; col < m; col++)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                int c = target[i] - 'a';
                dp[i + 1] = (dp[i + 1] + dp[i] * freq[col, c]) % mod;
            }
        }

        return (int)dp[n];
    }
}

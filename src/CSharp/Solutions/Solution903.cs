using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution903
{
    /// <summary>
    /// 903. Valid Permutations for DI Sequence - Hard
    /// <a href="https://leetcode.com/problems/valid-permutations-for-di-sequence">See the problem</a>
    /// </summary>
    public int NumPermsDISequence(string s)
    {
        int n = s.Length;
        int mod = 1000000007;
        var dp = new int[n + 1, n + 1];

        for (int i = 0; i <= n; i++)
        {
            dp[0, i] = 1;
        }

        for (int i = 0; i < n; i++)
        {
            if (s[i] == 'I')
            {
                for (int j = 0, cur = 0; j < n - i; j++)
                {
                    cur = (cur + dp[i, j]) % mod;
                    dp[i + 1, j] = cur;
                }
            }
            else
            {
                for (int j = n - i - 1, cur = 0; j >= 0; j--)
                {
                    cur = (cur + dp[i, j + 1]) % mod;
                    dp[i + 1, j] = cur;
                }
            }
        }

        return dp[n, 0];
    }
}

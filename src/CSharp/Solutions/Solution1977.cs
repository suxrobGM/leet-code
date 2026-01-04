namespace LeetCode.Solutions;

public class Solution1977
{
    /// <summary>
    /// 1977. Number of Ways to Separate Numbers - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-to-separate-numbers">See the problem</a>
    /// </summary>
    public int NumberOfCombinations(string num)
    {
        int n = num.Length;
        int MOD = 1000000007;

        // Edge case: leading zero
        if (num[0] == '0') return 0;

        // Precompute LCP (Longest Common Prefix)
        int[,] lcp = new int[n + 1, n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (num[i] == num[j])
                {
                    lcp[i, j] = lcp[i + 1, j + 1] + 1;
                }
            }
        }

        // dp[i][j] = ways to partition num[0..i] where last number starts at j
        long[,] dp = new long[n, n];
        // prefix[i][j] = sum of dp[i][0..j] for optimization
        long[,] prefix = new long[n, n];

        // Base case: first number
        dp[0, 0] = 1;
        prefix[0, 0] = 1;

        for (int i = 1; i < n; i++)
        {
            // First number extends to position i
            dp[i, 0] = 1;
            prefix[i, 0] = 1;

            for (int j = 1; j <= i; j++)
            {
                // Leading zero check
                if (num[j] == '0')
                {
                    prefix[i, j] = prefix[i, j - 1];
                    continue;
                }

                int newLen = i - j + 1; // Length of new number num[j..i]

                // Sum all dp[j-1][k] where num[k..j-1] has length < newLen
                // This means k > j - newLen
                if (j - newLen >= 0)
                {
                    dp[i, j] = (prefix[j - 1, j - 1] - prefix[j - 1, j - newLen] + MOD) % MOD;
                }
                else
                {
                    dp[i, j] = prefix[j - 1, j - 1];
                }

                // Check if num[k..j-1] == newLen (k = j - newLen)
                // Add only if num[k..j-1] <= num[j..i]
                if (j - newLen >= 0)
                {
                    if (Compare(num, j - newLen, j - 1, j, i, lcp) <= 0)
                    {
                        dp[i, j] = (dp[i, j] + dp[j - 1, j - newLen]) % MOD;
                    }
                }

                prefix[i, j] = (prefix[i, j - 1] + dp[i, j]) % MOD;
            }
        }

        return (int)prefix[n - 1, n - 1];
    }

    // Compare num[i1..j1] with num[i2..j2] using precomputed LCP
    // Returns: -1 if less, 0 if equal, 1 if greater
    private int Compare(string num, int i1, int j1, int i2, int j2, int[,] lcp)
    {
        int len1 = j1 - i1 + 1;
        int len2 = j2 - i2 + 1;

        // Different lengths
        if (len1 != len2)
        {
            return len1 < len2 ? -1 : 1;
        }

        // Same length: use LCP for O(1) comparison
        int commonLen = lcp[i1, i2];
        if (commonLen >= len1)
        {
            return 0; // Strings are equal
        }

        // First differing character
        return num[i1 + commonLen] < num[i2 + commonLen] ? -1 : 1;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1278
{
    /// <summary>
    /// 1278. Palindrome Partitioning III - Hard
    /// <a href="https://leetcode.com/problems/palindrome-partitioning-iii">See the problem</a>
    /// </summary>
    public int PalindromePartition(string s, int k)
    {
        int n = s.Length;
        if (k == 1) return MinChanges(s, 0, n - 1);
        if (k >= n) return 0;

        var dp = new int[n, k + 1];
        for (int i = 0; i < n; i++)
            for (int j = 1; j <= k; j++)
                dp[i, j] = int.MaxValue;

        for (int i = 0; i < n; i++)
            dp[i, 1] = MinChanges(s, 0, i);

        for (int j = 2; j <= k; j++)
        {
            for (int i = j - 1; i < n; i++)
            {
                for (int p = j - 2; p < i; p++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[p, j - 1] + MinChanges(s, p + 1, i));
                }
            }
        }

        return dp[n - 1, k];
    }

    private int MinChanges(string s, int start, int end)
    {
        int changes = 0;
        while (start < end)
        {
            if (s[start] != s[end])
                changes++;
            start++;
            end--;
        }
        return changes;
    }
}

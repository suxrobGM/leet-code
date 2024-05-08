namespace LeetCode.Solutions;

public class Solution132
{
    /// <summary>
    /// 132. Palindrome Partitioning II - Hard
    /// <a href="https://leetcode.com/problems/palindrome-partitioning-ii">See the problem</a>
    /// </summary>
    public int MinCut(string s)
    {
        var n = s.Length;
        var dp = new int[n];
        var isPalindrome = new bool[n, n];

        for (var i = 0; i < n; i++)
        {
            dp[i] = i;

            for (var j = 0; j <= i; j++)
            {
                if (s[i] == s[j] && (i - j <= 1 || isPalindrome[j + 1, i - 1]))
                {
                    isPalindrome[j, i] = true;
                    dp[i] = j == 0 ? 0 : Math.Min(dp[i], dp[j - 1] + 1);
                }
            }
        }

        return dp[n - 1];
    }
}

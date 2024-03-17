namespace LeetCode.Solutions;

public class Solution44
{
    /// <summary>
    /// 44. Wildcard Matching - Hard
    /// <a href="https://leetcode.com/problems/wildcard-matching">See the problem</a>
    /// </summary>
    public bool IsMatch(string s, string p)
    {
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;
        
        // Fill the first row
        for (var i = 1; i <= p.Length; i++)
        {
            if (p[i - 1] == '*')
            {
                dp[0, i] = dp[0, i - 1];
            }
        }
        
        // Fill the rest of the table
        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 1; j <= p.Length; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                }
                else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
            }
        }
        
        return dp[s.Length, p.Length];
    }
}

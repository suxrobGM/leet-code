namespace LeetCode.Solutions;

public class Solution139
{
    /// <summary>
    /// 139. Word Break - Medium
    /// <a href="https://leetcode.com/problems/word-break">See the problem</a>
    /// </summary>
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var wordSet = new HashSet<string>(wordDict);
        var dp = new bool[s.Length + 1];
        dp[0] = true;

        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (dp[j] && wordSet.Contains(s[j..i]))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }
}

namespace LeetCode.Solutions;

public class Solution91
{
    /// <summary>
    /// 91. Decode Ways - Medium
    /// <a href="https://leetcode.com/problems/decode-ways">See the problem</a>
    /// </summary>
    public int NumDecodings(string s)
    {
        var dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;

        for (var i = 2; i <= s.Length; i++)
        {
            var oneDigit = int.Parse(s.Substring(i - 1, 1));
            var twoDigits = int.Parse(s.Substring(i - 2, 2));

            if (oneDigit >= 1)
            {
                dp[i] += dp[i - 1];
            }

            if (twoDigits is >= 10 and <= 26)
            {
                dp[i] += dp[i - 2];
            }
        }

        return dp[s.Length];
    }
}

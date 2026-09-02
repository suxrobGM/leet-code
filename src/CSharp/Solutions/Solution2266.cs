namespace LeetCode.Solutions;

public class Solution2266
{
    /// <summary>
    /// 2266. Count Number of Texts - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-texts">See the problem</a>
    /// </summary>
    public int CountTexts(string pressedKeys)
    {
        const int mod = 1_000_000_007;

        // dp[i] = number of possible texts for the first i characters.
        var dp = new long[pressedKeys.Length + 1];
        dp[0] = 1;

        for (var i = 1; i <= pressedKeys.Length; i++)
        {
            var key = pressedKeys[i - 1];
            var maxPresses = key is '7' or '9' ? 4 : 3;

            // The last letter is formed by 1..maxPresses consecutive equal digits.
            for (var take = 1; take <= maxPresses && i - take >= 0; take++)
            {
                if (pressedKeys[i - take] != key)
                {
                    break;
                }

                dp[i] = (dp[i] + dp[i - take]) % mod;
            }
        }

        return (int)dp[pressedKeys.Length];
    }
}

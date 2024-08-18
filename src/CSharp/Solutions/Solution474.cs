namespace LeetCode.Solutions;

public class Solution474
{
    /// <summary>
    /// 474. Ones and Zeroes - Medium
    /// <a href="https://leetcode.com/problems/ones-and-zeroes">See the problem</a>
    /// </summary>
    public int FindMaxForm(string[] strs, int m, int n)
    {
        var dp = new int[m + 1, n + 1];

        foreach (var str in strs)
        {
            var zeros = str.Count(c => c == '0');
            var ones = str.Length - zeros;

            for (int i = m; i >= zeros; i--)
            {
                for (int j = n; j >= ones; j--)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
                }
            }
        }

        return dp[m, n];
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution879
{
    /// <summary>
    /// 879. Profitable Schemes - Hard
    /// <a href="https://leetcode.com/problems/profitable-schemes">See the problem</a>
    /// </summary>
    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        int mod = 1_000_000_007;
        int len = group.Length;
        int[,] dp = new int[n + 1, minProfit + 1];
        dp[0, 0] = 1;

        for (int i = 0; i < len; i++)
        {
            int g = group[i];
            int p = profit[i];

            for (int j = n; j >= g; j--)
            {
                for (int k = minProfit; k >= 0; k--)
                {
                    dp[j, k] = (dp[j, k] + dp[j - g, Math.Max(0, k - p)]) % mod;
                }
            }
        }

        int result = 0;

        for (int i = 0; i <= n; i++)
        {
            result = (result + dp[i, minProfit]) % mod;
        }

        return result;
    }
}

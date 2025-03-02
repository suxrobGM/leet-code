using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1039
{
    /// <summary>
    /// 1039. Minimum Score Triangulation of Polygon - Medium
    /// <a href="https://leetcode.com/problems/minimum-score-triangulation-of-polygon</a>
    /// </summary>
    public int MinScoreTriangulation(int[] values)
    {
        int n = values.Length;
        var dp = new int[n, n];

        for (int len = 2; len < n; len++)
        {
            for (int i = 0; i + len < n; i++)
            {
                int j = i + len;
                dp[i, j] = int.MaxValue;

                for (int k = i + 1; k < j; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k, j] + values[i] * values[j] * values[k]);
                }
            }
        }

        return dp[0, n - 1];
    }
}

namespace LeetCode.Solutions;

public class Solution63
{
    /// <summary>
    /// 63. Unique Paths II - Medium
    /// <a href="https://leetcode.com/problems/unique-paths-ii">See the problem</a>
    /// </summary>
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;
        var dp = new int[m, n];
        
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i, j] = 0;
                }
                else if (i == 0 && j == 0)
                {
                    dp[i, j] = 1;
                }
                else if (i == 0)
                {
                    dp[i, j] = dp[i, j - 1];
                }
                else if (j == 0)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
        }
        
        return dp[m - 1, n - 1];
    }
}

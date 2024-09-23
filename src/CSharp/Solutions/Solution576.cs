using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution576
{
    /// <summary>
    /// 576. Out of Boundary Paths - Medium
    /// <a href="https://leetcode.com/problems/out-of-boundary-paths">See the problem</a>
    /// </summary>
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        var dp = new int[m, n, maxMove + 1];
        var mod = 1000000007;
        var directions = new int[] { 0, 1, 0, -1, 0 };

        for (var move = 1; move <= maxMove; move++)
        {
            for (var row = 0; row < m; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    for (var i = 0; i < 4; i++)
                    {
                        var newRow = row + directions[i];
                        var newColumn = column + directions[i + 1];

                        if (newRow < 0 || newRow >= m || newColumn < 0 || newColumn >= n)
                        {
                            dp[row, column, move] += 1;
                        }
                        else
                        {
                            dp[row, column, move] = (dp[row, column, move] + dp[newRow, newColumn, move - 1]) % mod;
                        }
                    }
                }
            }
        }

        return dp[startRow, startColumn, maxMove];
    }
}

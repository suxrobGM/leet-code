using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution174
{
    /// <summary>
    /// 174. Dungeon Game - Hard
    /// <a href="https://leetcode.com/problems/dungeon-game">See the problem</a>
    /// </summary>
    public int CalculateMinimumHP(int[][] dungeon) 
    {
        var m = dungeon.Length;
        var n = dungeon[0].Length;
        var dp = new int[m + 1, n + 1];
        
        for (var i = 0; i <= m; i++)
        {
            for (var j = 0; j <= n; j++)
            {
                dp[i, j] = int.MaxValue;
            }
        }
        
        dp[m, n - 1] = 1;
        dp[m - 1, n] = 1;
        
        for (var i = m - 1; i >= 0; i--)
        {
            for (var j = n - 1; j >= 0; j--)
            {
                var min = Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j];
                dp[i, j] = min <= 0 ? 1 : min;
            }
        }
        
        return dp[0, 0];    
    }
}

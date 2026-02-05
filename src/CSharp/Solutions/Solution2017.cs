namespace LeetCode.Solutions;

public class Solution2017
{
    /// <summary>
    /// 2017. Grid Game - Medium
    /// <a href="https://leetcode.com/problems/grid-game">See the problem</a>
    /// </summary>
    public long GridGame(int[][] grid)
    {
        int n = grid[0].Length;

        long topRowSum = 0;
        for (int i = 0; i < n; i++)
            topRowSum += grid[0][i];

        long bottomRowSum = 0;
        long result = long.MaxValue;

        for (int i = 0; i < n; i++)
        {
            topRowSum -= grid[0][i];
            result = Math.Min(result, Math.Max(topRowSum, bottomRowSum));
            bottomRowSum += grid[1][i];
        }

        return result;
    }
}

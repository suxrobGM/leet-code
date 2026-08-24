namespace LeetCode.Solutions;

public class Solution2257
{
    private const byte Empty = 0;
    private const byte Guard = 1;
    private const byte Wall = 2;
    private const byte Guarded = 3;

    /// <summary>
    /// 2257. Count Unguarded Cells in the Grid - Medium
    /// <a href="https://leetcode.com/problems/count-unguarded-cells-in-the-grid">See the problem</a>
    /// </summary>
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var grid = new byte[m, n];

        foreach (var guard in guards)
        {
            grid[guard[0], guard[1]] = Guard;
        }

        foreach (var wall in walls)
        {
            grid[wall[0], wall[1]] = Wall;
        }

        for (var row = 0; row < m; row++)
        {
            var watched = false;

            for (var col = 0; col < n; col++)
            {
                watched = Sweep(grid, row, col, watched);
            }

            watched = false;

            for (var col = n - 1; col >= 0; col--)
            {
                watched = Sweep(grid, row, col, watched);
            }
        }

        for (var col = 0; col < n; col++)
        {
            var watched = false;

            for (var row = 0; row < m; row++)
            {
                watched = Sweep(grid, row, col, watched);
            }

            watched = false;

            for (var row = m - 1; row >= 0; row--)
            {
                watched = Sweep(grid, row, col, watched);
            }
        }

        var unguarded = 0;

        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
            {
                if (grid[row, col] == Empty)
                {
                    unguarded++;
                }
            }
        }

        return unguarded;
    }

    private static bool Sweep(byte[,] grid, int row, int col, bool watched)
    {
        var cell = grid[row, col];

        if (cell == Guard)
        {
            return true;
        }

        if (cell == Wall)
        {
            return false;
        }

        if (watched)
        {
            grid[row, col] = Guarded;
        }

        return watched;
    }
}

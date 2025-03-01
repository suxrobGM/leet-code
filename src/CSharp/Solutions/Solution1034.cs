using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1034
{
    private int rows, cols;
    private int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];

    /// <summary>
    /// 1034. Coloring A Border - Medium
    /// <a href="https://leetcode.com/problems/coloring-a-border</a>
    /// </summary>
    public int[][] ColorBorder(int[][] grid, int row, int col, int color)
    {
        rows = grid.Length;
        cols = grid[0].Length;
        int originalColor = grid[row][col];

        var component = new HashSet<(int, int)>();
        var borders = new HashSet<(int, int)>();
        
        DFS(grid, row, col, originalColor, component, borders);

        // Update the border cells with the new color
        foreach (var (r, c) in borders)
        {
            grid[r][c] = color;
        }

        return grid;
    }

    private void DFS(int[][] grid, int r, int c, int originalColor, HashSet<(int, int)> component, HashSet<(int, int)> borders)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] != originalColor || component.Contains((r, c)))
            return;

        component.Add((r, c));

        bool isBorder = false;
        foreach (var dir in directions)
        {
            int nr = r + dir[0], nc = c + dir[1];

            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || grid[nr][nc] != originalColor)
                isBorder = true;
            else if (!component.Contains((nr, nc)))
                DFS(grid, nr, nc, originalColor, component, borders);
        }

        if (isBorder)
            borders.Add((r, c));
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution840
{
    /// <summary>
    /// 840. Magic Squares In Grid - Medium
    /// <a href="https://leetcode.com/problems/magic-squares-in-grid">See the problem</a>
    /// </summary>
    public int NumMagicSquaresInside(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var count = 0;

        for (var i = 0; i < rows - 2; i++)
        {
            for (var j = 0; j < cols - 2; j++)
            {
                if (IsMagicSquare(grid, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsMagicSquare(int[][] grid, int i, int j)
    {
        var sum = grid[i][j] + grid[i][j + 1] + grid[i][j + 2];
        if (sum != grid[i + 1][j] + grid[i + 1][j + 1] + grid[i + 1][j + 2]) return false;
        if (sum != grid[i + 2][j] + grid[i + 2][j + 1] + grid[i + 2][j + 2]) return false;
        if (sum != grid[i][j] + grid[i + 1][j] + grid[i + 2][j]) return false;
        if (sum != grid[i][j + 1] + grid[i + 1][j + 1] + grid[i + 2][j + 1]) return false;
        if (sum != grid[i][j + 2] + grid[i + 1][j + 2] + grid[i + 2][j + 2]) return false;
        if (sum != grid[i][j] + grid[i + 1][j + 1] + grid[i + 2][j + 2]) return false;
        if (sum != grid[i][j + 2] + grid[i + 1][j + 1] + grid[i + 2][j]) return false;

        var nums = new int[10];
        for (var x = i; x < i + 3; x++)
        {
            for (var y = j; y < j + 3; y++)
            {
                if (grid[x][y] < 1 || grid[x][y] > 9 || nums[grid[x][y]] > 0) return false;
                nums[grid[x][y]]++;
            }
        }

        return true;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1260
{
    /// <summary>
    /// 1260. Shift 2D Grid - Easy
    /// <a href="https://leetcode.com/problems/shift-2d-grid">See the problem</a>
    /// </summary>
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var result = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            result[i] = new int[cols];
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int newRow = (i + (j + k) / cols) % rows;
                int newCol = (j + k) % cols;
                result[newRow][newCol] = grid[i][j];
            }
        }

        return result;
    }
}

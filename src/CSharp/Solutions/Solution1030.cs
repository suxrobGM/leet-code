using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1030
{
    /// <summary>
    /// 1030. Matrix Cells in Distance Order - Easy
    /// <a href="https://leetcode.com/problems/matrix-cells-in-distance-order</a>
    /// </summary>
    public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
    {
        var cells = new int[rows * cols][];
        int i = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                cells[i++] = [r, c];
            }
        }

        Array.Sort(cells, (a, b) => Distance(a, rCenter, cCenter) - Distance(b, rCenter, cCenter));

        return cells;
    }

    private int Distance(int[] cell, int rCenter, int cCenter)
    {
        return Math.Abs(cell[0] - rCenter) + Math.Abs(cell[1] - cCenter);
    }
}

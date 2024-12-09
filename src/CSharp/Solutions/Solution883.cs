using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution883
{
    /// <summary>
    /// 883. Projection Area of 3D Shapes - Easy
    /// <a href="https://leetcode.com/problems/projection-area-of-3d-shapes">See the problem</a>
    /// </summary>
    public int ProjectionArea(int[][] grid)
    {
        int n = grid.Length;
        int xy = 0;
        int xz = 0;
        int yz = 0;

        for (int i = 0; i < n; i++)
        {
            int maxRow = 0;
            int maxCol = 0;

            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0) xy++;
                maxRow = Math.Max(maxRow, grid[i][j]);
                maxCol = Math.Max(maxCol, grid[j][i]);
            }

            xz += maxRow;
            yz += maxCol;
        }

        return xy + xz + yz;
    }
}

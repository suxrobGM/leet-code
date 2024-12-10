using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution892
{
    /// <summary>
    /// 892. Surface Area of 3D Shapes - Easy
    /// <a href="https://leetcode.com/problems/surface-area-of-3d-shapes">See the problem</a>
    /// </summary>
    public int SurfaceArea(int[][] grid)
    {
        int n = grid.Length;
        int result = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0)
                {
                    result += 2 + grid[i][j] * 4;
                }

                if (i > 0)
                {
                    result -= Math.Min(grid[i][j], grid[i - 1][j]) * 2;
                }

                if (j > 0)
                {
                    result -= Math.Min(grid[i][j], grid[i][j - 1]) * 2;
                }
            }
        }

        return result;
    }
}

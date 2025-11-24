using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1914
{
    /// <summary>
    /// 1914. Cyclically Rotating a Grid - Medium
    /// <a href="https://leetcode.com/problems/cyclically-rotating-a-grid">See the problem</a>
    /// </summary>
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int layers = Math.Min(m, n) / 2;

        for (int layer = 0; layer < layers; layer++)
        {
            int top = layer;
            int left = layer;
            int bottom = m - 1 - layer;
            int right = n - 1 - layer;

            // Collect positions in this layer in clockwise order
            var coords = new List<int[]>();

            // Top row (left -> right)
            for (int j = left; j <= right; j++)
                coords.Add([top, j]);

            // Right column (top+1 -> bottom-1)
            for (int i = top + 1; i <= bottom - 1; i++)
                coords.Add([i, right]);

            // Bottom row (right -> left)
            if (bottom > top)
            {
                for (int j = right; j >= left; j--)
                    coords.Add([bottom, j]);
            }

            // Left column (bottom-1 -> top+1)
            if (right > left)
            {
                for (int i = bottom - 1; i >= top + 1; i--)
                    coords.Add([i, left]);
            }

            int len = coords.Count;
            int[] ring = new int[len];

            // Read current layer values into ring
            for (int idx = 0; idx < len; idx++)
            {
                int r = coords[idx][0];
                int c = coords[idx][1];
                ring[idx] = grid[r][c];
            }

            // Effective left-rotation by k (counter-clockwise)
            int kEff = k % len;

            // Write rotated values back into grid
            for (int idx = 0; idx < len; idx++)
            {
                int r = coords[idx][0];
                int c = coords[idx][1];

                // Left-rotate: new[idx] = ring[(idx + kEff) % len]
                grid[r][c] = ring[(idx + kEff) % len];
            }
        }

        return grid;
    }
}

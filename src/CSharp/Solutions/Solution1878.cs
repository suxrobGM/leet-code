using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1878
{
    /// <summary>
    /// 1878. Get Biggest Three Rhombus Sums in a Grid - Medium
    /// <a href="https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid">See the problem</a>
    /// </summary>
    public int[] GetBiggestThree(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        var top = new SortedSet<long>(); // ascending; we'll trim to at most 3 distinct sums

        // Helper to try insert into top-3 distinct
        void Insert(long val)
        {
            if (top.Contains(val)) return;
            top.Add(val);
            if (top.Count > 3) top.Remove(top.Min);
        }

        // Add all 0-area rhombi (single cells)
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                Insert(grid[i][j]);

        // For each center (i,j), try all radii r >= 1 that fit fully in bounds
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int maxR = Math.Min(Math.Min(i, m - 1 - i), Math.Min(j, n - 1 - j));
                for (int r = 1; r <= maxR; r++)
                {
                    long sum = 0;

                    int ti = i - r, tj = j;       // top
                    int ri = i, rj = j + r;   // right
                    int bi = i + r, bj = j;       // bottom
                    int li = i, lj = j - r;   // left

                    // corners once
                    sum += grid[ti][tj];
                    sum += grid[ri][rj];
                    sum += grid[bi][bj];
                    sum += grid[li][lj];

                    // internal border points on four sides (exclude endpoints to avoid double-counting corners)
                    for (int k = 1; k < r; k++)
                    {
                        // top -> right (down-right)
                        sum += grid[ti + k][tj + k];
                        // right -> bottom (down-left)
                        sum += grid[ri + k][rj - k];
                        // bottom -> left (up-left)
                        sum += grid[bi - k][bj - k];
                        // left -> top (up-right)
                        sum += grid[li - k][lj + k];
                    }

                    Insert(sum);
                }
            }
        }

        // Return in descending order
        return top.Reverse().Select(x => (int)x).ToArray();
    }
}

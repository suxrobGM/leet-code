using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1727
{
    /// <summary>
    /// 1727. Largest Submatrix With Rearrangements - Medium
    /// <a href="https://leetcode.com/problems/largest-submatrix-with-rearrangements">See the problem</a>
    /// </summary>
    public int LargestSubmatrix(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var heights = new int[n];
        var buf = new int[n];
        long best = 0;

        for (int r = 0; r < m; r++)
        {
            // Update heights for this row
            for (int c = 0; c < n; c++)
                heights[c] = (matrix[r][c] == 1) ? heights[c] + 1 : 0;

            // Copy to buffer and sort ascending; we'll scan from the end
            Array.Copy(heights, buf, n);
            Array.Sort(buf); // O(n log n)

            // Try widths 1..n with tallest columns first
            for (int i = n - 1, width = 1; i >= 0; i--, width++)
            {
                if (buf[i] == 0) break; // no area beyond this
                long area = (long)buf[i] * width;
                if (area > best) best = area;
            }
        }

        return (int)best;
    }
}

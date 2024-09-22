using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution566
{
    /// <summary>
    /// 566. Reshape the Matrix - Easy
    /// <a href="https://leetcode.com/problems/reshape-the-matrix">See the problem</a>
    /// </summary>
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        if (m * n != r * c)
        {
            return mat;
        }

        var result = new int[r][];
        for (var i = 0; i < r; i++)
        {
            result[i] = new int[c];
        }

        var row = 0;
        var col = 0;
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result[row][col] = mat[i][j];
                col++;
                if (col == c)
                {
                    col = 0;
                    row++;
                }
            }
        }

        return result;
    }
}

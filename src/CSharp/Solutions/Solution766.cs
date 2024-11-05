using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution766
{
    /// <summary>
    /// 766. Toeplitz Matrix - Easy
    /// <a href="https://leetcode.com/problems/toeplitz-matrix">See the problem</a>
    /// </summary>
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        for (var i = 0; i < m - 1; i++)
        {
            for (var j = 0; j < n - 1; j++)
            {
                if (matrix[i][j] != matrix[i + 1][j + 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}

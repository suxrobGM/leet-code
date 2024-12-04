using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution867
{
    /// <summary>
    /// 867. Transpose Matrix - Easy
    /// <a href="https://leetcode.com/problems/transpose-matrix">See the problem</a>
    /// </summary>
    public int[][] Transpose(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var result = new int[n][];

        for (int i = 0; i < n; i++)
        {
            result[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                result[i][j] = matrix[j][i];
            }
        }

        return result;
    }
}

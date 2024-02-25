namespace LeetCode.Solutions;

public class Solution73
{
    /// <summary>
    /// 73. Set Matrix Zeroes
    /// <a href="https://leetcode.com/problems/set-matrix-zeroes">See the problem</a>
    /// </summary>
    public void SetZeroes(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var firstRowHasZero = false;
        var firstColHasZero = false;

        // Check if the first first column have any zeros
        for (var i = 0; i < m; i++)
        {
            if (matrix[i][0] == 0)
            {
                firstColHasZero = true;
                break;
            }
        }

        // Check if the first row column have any zeros
        for (var i = 0; i < n; i++)
        {
            if (matrix[0][i] == 0)
            {
                firstRowHasZero = true;
                break;
            }
        }

        // Check for zeros in the rest of the matrix
        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        // Set zeros based on the first row and column
        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // Set zeros for the first row and column
        if (firstRowHasZero)
        {
            for (var i = 0; i < n; i++)
            {
                matrix[0][i] = 0;
            }
        }

        // Set zeros for the first column
        if (firstColHasZero)
        {
            for (var i = 0; i < m; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
}

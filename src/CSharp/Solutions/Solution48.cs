namespace LeetCode.Solutions;

public class Solution48
{
    /// <summary>
    /// 48. Rotate Image
    /// <a href="https://leetcode.com/problems/rotate-image">See the problem</a>
    /// </summary>
    public void Rotate(int[][] matrix)
    {
        var n = matrix.Length;

        // Reverse each column
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n / 2; j++)
            {
                (matrix[j][i], matrix[n - j - 1][i]) = (matrix[n - j - 1][i], matrix[j][i]);
            }
        }
        
        // Transpose the matrix
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }
    }
}

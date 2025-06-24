using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1572
{
    /// <summary>
    /// 1572. Matrix Diagonal Sum - Easy
    /// <a href="https://leetcode.com/problems/matrix-diagonal-sum">See the problem</a>
    /// </summary>
    public int DiagonalSum(int[][] mat)
    {
        int n = mat.Length;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += mat[i][i];               // Primary diagonal
            sum += mat[i][n - 1 - i];       // Secondary diagonal
        }

        // Subtract the middle element once if n is odd (as it's counted twice)
        if (n % 2 == 1)
        {
            sum -= mat[n / 2][n / 2];
        }

        return sum;
    }
}

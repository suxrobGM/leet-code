namespace LeetCode.Solutions;

public class Solution240
{
    /// <summary>
    /// 240. Search a 2D Matrix II - Medium
    /// <a href="https://leetcode.com/problems/search-a-2d-matrix-ii">See the problem</a>
    /// </summary>
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var row = 0;
        var col = matrix[0].Length - 1;

        while (row < matrix.Length && col >= 0)
        {
            if (matrix[row][col] == target)
            {
                return true;
            }
            else if (matrix[row][col] < target)
            {
                row++;
            }
            else
            {
                col--;
            }
        }

        return false;
    }
}

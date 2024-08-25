namespace LeetCode.Solutions;

public class Solution498
{
    /// <summary>
    /// 498. Diagonal Traverse - Medium
    /// <a href="https://leetcode.com/problems/diagonal-traverse">See the problem</a>
    /// </summary>
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat.Length == 0)
        {
            return [];
        }

        int rows = mat.Length;
        int cols = mat[0].Length;
        int[] result = new int[rows * cols];
        int row = 0;
        int col = 0;

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = mat[row][col];

            if ((row + col) % 2 == 0)
            {
                if (col == cols - 1)
                {
                    row++;
                }
                else if (row == 0)
                {
                    col++;
                }
                else
                {
                    row--;
                    col++;
                }
            }
            else
            {
                if (row == rows - 1)
                {
                    col++;
                }
                else if (col == 0)
                {
                    row++;
                }
                else
                {
                    row++;
                    col--;
                }
            }
        }

        return result;
    }
}

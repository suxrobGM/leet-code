namespace LeetCode.Solutions;

public class Solution2373
{
    /// <summary>
    /// 2373. Largest Local Values in a Matrix - Easy
    /// <a href="https://leetcode.com/problems/largest-local-values-in-a-matrix">See the problem</a>
    /// </summary>
    public int[][] LargestLocal(int[][] grid)
    {
        int size = grid.Length - 2;
        int[][] maxLocal = new int[size][];

        for (int row = 0; row < size; row++)
        {
            maxLocal[row] = new int[size];

            for (int col = 0; col < size; col++)
            {
                int max = grid[row][col];

                for (int r = row; r < row + 3; r++)
                {
                    for (int c = col; c < col + 3; c++)
                    {
                        max = Math.Max(max, grid[r][c]);
                    }
                }

                maxLocal[row][col] = max;
            }
        }

        return maxLocal;
    }
}

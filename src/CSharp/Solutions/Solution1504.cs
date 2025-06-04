using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1504
{
    /// <summary>
    /// 1504. Count Submatrices With All Ones - Medium
    /// <a href="https://leetcode.com/problems/count-submatrices-with-all-ones">See the problem</a>
    /// </summary>
    public int NumSubmat(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        var height = new int[m, n];

        // Step 1: Build histogram for each column
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0) height[i, j] = 0;
                else height[i, j] = (i == 0 ? 1 : height[i - 1, j] + 1);
            }
        }

        int count = 0;

        // Step 2: Count submatrices ending at each cell (i, j)
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int minHeight = int.MaxValue;
                for (int k = j; k >= 0; k--)
                {
                    if (height[i, k] == 0) break;
                    minHeight = Math.Min(minHeight, height[i, k]);
                    count += minHeight;
                }
            }
        }

        return count;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1292
{
    /// <summary>
    /// 1292. Maximum Side Length of a Square with Sum Less than or Equal to Threshold - Medium
    /// <a href="https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold">See the problem</a>
    /// </summary>
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;
        int maxSide = 0;

        // Create a prefix sum array
        var prefixSum = new int[rows + 1][];
        for (int i = 0; i <= rows; i++)
        {
            prefixSum[i] = new int[cols + 1];
        }

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                prefixSum[i][j] = mat[i - 1][j - 1] + prefixSum[i - 1][j] + prefixSum[i][j - 1] - prefixSum[i - 1][j - 1];
            }
        }

        // Check for the maximum side length
        for (int side = 1; side <= Math.Min(rows, cols); side++)
        {
            for (int i = side; i <= rows; i++)
            {
                for (int j = side; j <= cols; j++)
                {
                    int sum = prefixSum[i][j] - prefixSum[i - side][j] - prefixSum[i][j - side] + prefixSum[i - side][j - side];
                    if (sum <= threshold)
                    {
                        maxSide = Math.Max(maxSide, side);
                    }
                }
            }
        }

        return maxSide;
    }
}

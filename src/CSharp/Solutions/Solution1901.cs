using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1901
{
    /// <summary>
    /// 1901. Find a Peak Element II - Medium
    /// <a href="https://leetcode.com/problems/find-a-peak-element-ii">See the problem</a>
    /// </summary>
    public int[] FindPeakGrid(int[][] mat)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;

        int left = 0, right = cols - 1;

        while (left <= right)
        {
            int midCol = left + (right - left) / 2;

            // Find the row index of the maximum element in the midCol
            int maxRow = 0;
            for (int r = 1; r < rows; r++)
            {
                if (mat[r][midCol] > mat[maxRow][midCol])
                {
                    maxRow = r;
                }
            }

            bool isLeftBigger = (midCol - 1 >= 0) && (mat[maxRow][midCol - 1] > mat[maxRow][midCol]);
            bool isRightBigger = (midCol + 1 < cols) && (mat[maxRow][midCol + 1] > mat[maxRow][midCol]);

            if (!isLeftBigger && !isRightBigger)
            {
                return [maxRow, midCol];
            }
            else if (isRightBigger)
            {
                left = midCol + 1;
            }
            else
            {
                right = midCol - 1;
            }
        }

        return [-1, -1]; // This line should never be reached
    }
}

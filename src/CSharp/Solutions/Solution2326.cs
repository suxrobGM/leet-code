using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2326
{
    /// <summary>
    /// 2326. Spiral Matrix IV - Medium
    /// <a href="https://leetcode.com/problems/spiral-matrix-iv">See the problem</a>
    /// </summary>
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        var matrix = new int[m][];
        for (var row = 0; row < m; row++)
        {
            matrix[row] = new int[n];
            Array.Fill(matrix[row], -1);
        }

        var top = 0;
        var bottom = m - 1;
        var left = 0;
        var right = n - 1;

        while (head != null && top <= bottom && left <= right)
        {
            for (var column = left; column <= right && head != null; column++)
            {
                matrix[top][column] = head.val;
                head = head.next;
            }
            top++;

            for (var row = top; row <= bottom && head != null; row++)
            {
                matrix[row][right] = head.val;
                head = head.next;
            }
            right--;

            if (top <= bottom)
            {
                for (var column = right; column >= left && head != null; column--)
                {
                    matrix[bottom][column] = head.val;
                    head = head.next;
                }
                bottom--;
            }

            if (left <= right)
            {
                for (var row = bottom; row >= top && head != null; row--)
                {
                    matrix[row][left] = head.val;
                    head = head.next;
                }
                left++;
            }
        }

        return matrix;
    }
}

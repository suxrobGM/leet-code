namespace LeetCode.Solutions;

public class Solution378
{
    /// <summary>
    /// 378. Kth Smallest Element in a Sorted Matrix - Medium
    /// <a href="https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix">See the problem</a>
    /// </summary>
    public int KthSmallest(int[][] matrix, int k)
    {
        var n = matrix.Length;
        var left = matrix[0][0];
        var right = matrix[n - 1][n - 1];

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var count = Count(matrix, mid);

            if (count < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }

    private int Count(int[][] matrix, int target)
    {
        var n = matrix.Length;
        var count = 0;
        var i = n - 1;
        var j = 0;

        while (i >= 0 && j < n)
        {
            if (matrix[i][j] <= target)
            {
                count += i + 1;
                j++;
            }
            else
            {
                i--;
            }
        }

        return count;
    }
}

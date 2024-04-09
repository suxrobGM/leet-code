namespace LeetCode.Solutions;

public class Solution74
{
    /// <summary>
    /// 74. Search a 2D Matrix - Medium
    /// <a href="https://leetcode.com/problems/search-a-2d-matrix">See the problem</a>
    /// </summary>
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var left = 0;
        var right = m * n - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midElement = matrix[mid / n][mid % n];

            if (midElement == target)
            {
                return true;
            }
            else if (midElement < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
}

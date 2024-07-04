using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution304
{
    /// <summary>
    /// 304. Range Sum Query 2D - Immutable - Medium
    /// <a href="https://leetcode.com/problems/range-sum-query-2d-immutable">See the problem</a>
    /// </summary>
    public class NumMatrix 
    {
        private readonly int[,] _sums;

        public NumMatrix(int[][] matrix) 
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            _sums = new int[rows + 1, cols + 1];

            for (var i = 1; i <= rows; i++)
            {
                for (var j = 1; j <= cols; j++)
                {
                    _sums[i, j] = matrix[i - 1][j - 1] + _sums[i - 1, j] + _sums[i, j - 1] - _sums[i - 1, j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2) 
        {
            return _sums[row2 + 1, col2 + 1] - _sums[row1, col2 + 1] - _sums[row2 + 1, col1] + _sums[row1, col1];
        }
    }
}

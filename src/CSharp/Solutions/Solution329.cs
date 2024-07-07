using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution329
{
    /// <summary>
    /// 329. Longest Increasing Path in a Matrix - Hard
    /// <a href="https://leetcode.com/problems/longest-increasing-path-in-a-matrix">See the problem</a>
    /// </summary>
    public int LongestIncreasingPath(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var cache = new int[rows, cols];
        var result = 0;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                result = Math.Max(result, Dfs(matrix, i, j, cache));
            }
        }

        return result;
    }

    private int Dfs(int[][] matrix, int i, int j, int[,] cache)
    {
        if (cache[i, j] != 0)
        {
            return cache[i, j];
        }

        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var result = 1;

        foreach (var (dx, dy) in new[] { (0, 1), (1, 0), (0, -1), (-1, 0) })
        {
            var x = i + dx;
            var y = j + dy;

            if (x < 0 || x >= rows || y < 0 || y >= cols || matrix[x][y] <= matrix[i][j])
            {
                continue;
            }

            result = Math.Max(result, 1 + Dfs(matrix, x, y, cache));
        }

        cache[i, j] = result;

        return result;
    }
}

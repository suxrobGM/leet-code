using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution542
{
    /// <summary>
    /// 542. 01 Matrix - Medium
    /// <a href="https://leetcode.com/problems/01-matrix">See the problem</a>
    /// </summary>
    public int[][] UpdateMatrix(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var queue = new Queue<(int, int)>();
        var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                {
                    queue.Enqueue((i, j));
                }
                else
                {
                    mat[i][j] = int.MaxValue;
                }
            }
        }

        while (queue.Count > 0)
        {
            var (i, j) = queue.Dequeue();
            foreach (var (di, dj) in directions)
            {
                var ni = i + di;
                var nj = j + dj;
                if (ni < 0 || ni >= m || nj < 0 || nj >= n || mat[ni][nj] <= mat[i][j] + 1)
                {
                    continue;
                }

                mat[ni][nj] = mat[i][j] + 1;
                queue.Enqueue((ni, nj));
            }
        }

        return mat;
    }
}

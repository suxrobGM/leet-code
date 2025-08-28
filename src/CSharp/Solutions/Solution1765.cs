using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1765
{
    /// <summary>
    /// 1765. Map of Highest Peak - Medium
    /// <a href="https://leetcode.com/problems/map-of-highest-peak">See the problem</a>
    /// </summary>
    public int[][] HighestPeak(int[][] isWater)
    {
        int m = isWater.Length, n = isWater[0].Length;
        var height = new int[m][];
        for (int i = 0; i < m; i++)
        {
            height[i] = Enumerable.Repeat(-1, n).ToArray();
        }

        var q = new Queue<(int r, int c)>();

        // Initialize queue with water cells
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isWater[i][j] == 1)
                {
                    height[i][j] = 0;
                    q.Enqueue((i, j));
                }
            }
        }

        int[][] dirs = [
            [1,0], [-1,0], [0,1], [0,-1]
        ];

        // BFS expansion
        while (q.Count > 0)
        {
            var (r, c) = q.Dequeue();
            foreach (var d in dirs)
            {
                int nr = r + d[0], nc = c + d[1];
                if (nr >= 0 && nr < m && nc >= 0 && nc < n && height[nr][nc] == -1)
                {
                    height[nr][nc] = height[r][c] + 1;
                    q.Enqueue((nr, nc));
                }
            }
        }

        return height;
    }
}

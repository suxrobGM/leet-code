using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1568
{
    /// <summary>
    /// 1568. Minimum Number of Days to Disconnect Island - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-days-to-disconnect-island">See the problem</a>
    /// </summary>
    public int MinDays(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;

        // Count number of islands using DFS
        int CountIslands(int[][] g)
        {
            bool[,] visited = new bool[m, n];
            int count = 0;

            void Dfs(int i, int j)
            {
                if (i < 0 || j < 0 || i >= m || j >= n || g[i][j] == 0 || visited[i, j])
                    return;
                visited[i, j] = true;
                Dfs(i + 1, j);
                Dfs(i - 1, j);
                Dfs(i, j + 1);
                Dfs(i, j - 1);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (g[i][j] == 1 && !visited[i, j])
                    {
                        count++;
                        Dfs(i, j);
                    }
                }
            }

            return count;
        }

        if (CountIslands(grid) != 1)
            return 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 0;
                    if (CountIslands(grid) != 1)
                        return 1;
                    grid[i][j] = 1;
                }
            }
        }

        return 2;
    }
}

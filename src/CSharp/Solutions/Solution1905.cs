using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1905
{
    /// <summary>
    /// 1905. Count Sub Islands - Medium
    /// <a href="https://leetcode.com/problems/count-sub-islands">See the problem</a>
    /// </summary>
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        int rows = grid1.Length;
        int cols = grid1[0].Length;
        var visited = new bool[rows, cols];

        int CountIslands()
        {
            int subIslandCount = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid2[r][c] == 1 && !visited[r, c])
                    {
                        bool isSubIsland = true;
                        DFS(r, c, ref isSubIsland);
                        if (isSubIsland)
                        {
                            subIslandCount++;
                        }
                    }
                }
            }

            return subIslandCount;
        }

        void DFS(int r, int c, ref bool isSubIsland)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols || visited[r, c] || grid2[r][c] == 0)
            {
                return;
            }

            visited[r, c] = true;

            if (grid1[r][c] == 0)
            {
                isSubIsland = false;
            }

            DFS(r + 1, c, ref isSubIsland);
            DFS(r - 1, c, ref isSubIsland);
            DFS(r, c + 1, ref isSubIsland);
            DFS(r, c - 1, ref isSubIsland);
        }

        return CountIslands();
    }
}

using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution980
{
    /// <summary>
    /// 980. Unique Paths III - Hard
    /// <a href="https://leetcode.com/problems/unique-paths-iii">See the problem</a>
    /// </summary>
    public int UniquePathsIII(int[][] grid)
    {
        int moves = 0;
        int startRow = 0;
        int startCol = 0;
        int emptyCells = 1;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    startRow = i;
                    startCol = j;
                }
                else if (grid[i][j] == 0)
                {
                    emptyCells++;
                }
            }
        }

        Dfs(grid, startRow, startCol, emptyCells, ref moves);

        return moves;
    }

    private void Dfs(int[][] grid, int row, int col, int emptyCells, ref int moves)
    {
        if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == -1)
        {
            return;
        }

        if (grid[row][col] == 2)
        {
            if (emptyCells == 0)
            {
                moves++;
            }

            return;
        }

        grid[row][col] = -1;
        emptyCells--;

        Dfs(grid, row + 1, col, emptyCells, ref moves);
        Dfs(grid, row - 1, col, emptyCells, ref moves);
        Dfs(grid, row, col + 1, emptyCells, ref moves);
        Dfs(grid, row, col - 1, emptyCells, ref moves);

        grid[row][col] = 0;
    }
}

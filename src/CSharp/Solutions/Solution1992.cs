namespace LeetCode.Solutions;

public class Solution1992
{
    /// <summary>
    /// 1992. Find All Groups of Farmland - Medium
    /// <a href="https://leetcode.com/problems/find-all-groups-of-farmland">See the problem</a>
    /// </summary>
    public int[][] FindFarmland(int[][] land)
    {
        var result = new List<int[]>();
        int rows = land.Length;
        int cols = land[0].Length;
        var visited = new bool[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (land[r][c] == 1 && !visited[r, c])
                {
                    int startRow = r;
                    int startCol = c;
                    int endRow = r;
                    int endCol = c;

                    // Find the bottom-right corner of the farmland
                    while (endRow + 1 < rows && land[endRow + 1][c] == 1)
                    {
                        endRow++;
                    }
                    while (endCol + 1 < cols && land[r][endCol + 1] == 1)
                    {
                        endCol++;
                    }

                    // Mark all cells in the farmland as visited
                    for (int i = startRow; i <= endRow; i++)
                    {
                        for (int j = startCol; j <= endCol; j++)
                        {
                            visited[i, j] = true;
                        }
                    }

                    result.Add([startRow, startCol, endRow, endCol]);
                }
            }
        }

        return [.. result];
    }
}

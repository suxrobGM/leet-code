using System.Text;

namespace LeetCode.Solutions;

public class Solution417
{
    /// <summary>
    /// 417. Pacific Atlantic Water Flow - Medium
    /// <a href="https://leetcode.com/problems/pacific-atlantic-water-flow">See the problem</a>
    /// </summary>
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var result = new List<IList<int>>();
        var rows = heights.Length;
        var cols = heights[0].Length;
        var pacific = new bool[rows, cols];
        var atlantic = new bool[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            Dfs(heights, pacific, i, 0);
            Dfs(heights, atlantic, i, cols - 1);
        }

        for (var i = 0; i < cols; i++)
        {
            Dfs(heights, pacific, 0, i);
            Dfs(heights, atlantic, rows - 1, i);
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (pacific[i, j] && atlantic[i, j])
                {
                    result.Add(new List<int> { i, j });
                }
            }
        }

        return result;
    }

    private void Dfs(int[][] heights, bool[,] visited, int i, int j)
    {
        visited[i, j] = true;

        var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        foreach (var (dx, dy) in directions)
        {
            var x = i + dx;
            var y = j + dy;

            if (x < 0 || x >= heights.Length || y < 0 || y >= heights[0].Length || visited[x, y] || heights[x][y] < heights[i][j])
            {
                continue;
            }

            Dfs(heights, visited, x, y);
        }
    }
}

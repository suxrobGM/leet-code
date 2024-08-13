using System.Text;

namespace LeetCode.Solutions;

public class Solution463
{
    /// <summary>
    /// 463. Island Perimeter - Easy
    /// <a href="https://leetcode.com/problems/island-perimeter">See the problem</a>
    /// </summary>
    public int IslandPerimeter(int[][] grid)
    {
        var perimeter = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    perimeter += 4;

                    if (i > 0 && grid[i - 1][j] == 1)
                    {
                        perimeter -= 2;
                    }

                    if (j > 0 && grid[i][j - 1] == 1)
                    {
                        perimeter -= 2;
                    }
                }
            }
        }

        return perimeter;
    }
}

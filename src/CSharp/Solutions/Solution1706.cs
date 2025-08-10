using System.Text;


namespace LeetCode.Solutions;

public class Solution1706
{
    /// <summary>
    /// 1706. Where Will the Ball Fall - Medium
    /// <a href="https://leetcode.com/problems/where-will-the-ball-fall">See the problem</a>
    /// </summary>
    public int[] FindBall(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        var ans = new int[n];

        for (int start = 0; start < n; start++)
        {
            int c = start;
            for (int r = 0; r < m; r++)
            {
                int dir = grid[r][c];
                int nc = c + dir;

                // hits wall or V shape (neighbor board points opposite)
                if (nc < 0 || nc >= n || grid[r][nc] != dir)
                {
                    c = -1;
                    break;
                }

                c = nc; // move to next column in same row; drop to next row
            }
            ans[start] = c;
        }

        return ans;
    }
}

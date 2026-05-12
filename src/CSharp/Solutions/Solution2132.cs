namespace LeetCode.Solutions;

public class Solution2132
{
    /// <summary>
    /// 2132. Stamping the Grid - Hard
    /// <a href="https://leetcode.com/problems/stamping-the-grid">See the problem</a>
    /// </summary>
    public bool PossibleToStamp(int[][] grid, int stampHeight, int stampWidth)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        var gridPrefix = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                gridPrefix[i + 1, j + 1] = grid[i][j]
                    + gridPrefix[i, j + 1]
                    + gridPrefix[i + 1, j]
                    - gridPrefix[i, j];
            }
        }

        var stampPrefix = new int[m + 2, n + 2];
        for (int i = 0; i + stampHeight <= m; i++)
        {
            for (int j = 0; j + stampWidth <= n; j++)
            {
                int regionSum = gridPrefix[i + stampHeight, j + stampWidth]
                    - gridPrefix[i, j + stampWidth]
                    - gridPrefix[i + stampHeight, j]
                    + gridPrefix[i, j];
                if (regionSum == 0)
                {
                    stampPrefix[i + 1, j + 1] = 1;
                }
            }
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                stampPrefix[i, j] += stampPrefix[i - 1, j] + stampPrefix[i, j - 1] - stampPrefix[i - 1, j - 1];
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    continue;
                }

                int r1 = Math.Max(0, i - stampHeight + 1);
                int c1 = Math.Max(0, j - stampWidth + 1);
                int stampsInRange = stampPrefix[i + 1, j + 1]
                    - stampPrefix[r1, j + 1]
                    - stampPrefix[i + 1, c1]
                    + stampPrefix[r1, c1];

                if (stampsInRange == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}

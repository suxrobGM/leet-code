namespace LeetCode.Solutions;

public class Solution2319
{
    /// <summary>
    /// 2319. Check if Matrix Is X-Matrix - Easy
    /// <a href="https://leetcode.com/problems/check-if-matrix-is-x-matrix">See the problem</a>
    /// </summary>
    public bool CheckXMatrix(int[][] grid)
    {
        var n = grid.Length;

        for (var row = 0; row < n; row++)
        {
            for (var col = 0; col < n; col++)
            {
                var isDiagonal = row == col || row + col == n - 1;
                if (isDiagonal ? grid[row][col] == 0 : grid[row][col] != 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}

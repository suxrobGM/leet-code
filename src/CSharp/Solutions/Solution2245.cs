namespace LeetCode.Solutions;

public class Solution2245
{
    /// <summary>
    /// 2245. Maximum Trailing Zeros in a Cornered Path - Medium
    /// <a href="https://leetcode.com/problems/maximum-trailing-zeros-in-a-cornered-path">See the problem</a>
    /// </summary>
    public int MaxTrailingZeros(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        // Count of factors 2 and 5 for each cell
        var twos = new int[rows, cols];
        var fives = new int[rows, cols];
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                var value = grid[r][c];
                while (value % 2 == 0)
                {
                    twos[r, c]++;
                    value /= 2;
                }
                while (value % 5 == 0)
                {
                    fives[r, c]++;
                    value /= 5;
                }
            }
        }

        // Prefix sums along rows and columns (1-based)
        var rowTwos = new int[rows, cols + 1];
        var rowFives = new int[rows, cols + 1];
        var colTwos = new int[rows + 1, cols];
        var colFives = new int[rows + 1, cols];
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                rowTwos[r, c + 1] = rowTwos[r, c] + twos[r, c];
                rowFives[r, c + 1] = rowFives[r, c] + fives[r, c];
                colTwos[r + 1, c] = colTwos[r, c] + twos[r, c];
                colFives[r + 1, c] = colFives[r, c] + fives[r, c];
            }
        }

        var best = 0;
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                // Horizontal segments ending at (r, c): left part and right part (both include the cell)
                var leftTwos = rowTwos[r, c + 1];
                var leftFives = rowFives[r, c + 1];
                var rightTwos = rowTwos[r, cols] - rowTwos[r, c];
                var rightFives = rowFives[r, cols] - rowFives[r, c];

                // Vertical segments excluding the corner cell (r, c)
                var upTwos = colTwos[r, c];
                var upFives = colFives[r, c];
                var downTwos = colTwos[rows, c] - colTwos[r + 1, c];
                var downFives = colFives[rows, c] - colFives[r + 1, c];

                best = Math.Max(best, Math.Min(leftTwos + upTwos, leftFives + upFives));
                best = Math.Max(best, Math.Min(leftTwos + downTwos, leftFives + downFives));
                best = Math.Max(best, Math.Min(rightTwos + upTwos, rightFives + upFives));
                best = Math.Max(best, Math.Min(rightTwos + downTwos, rightFives + downFives));
            }
        }

        return best;
    }
}

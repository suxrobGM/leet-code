namespace LeetCode.Solutions;

public class Solution2267
{
    /// <summary>
    /// 2267. Check if There Is a Valid Parentheses String Path - Hard
    /// <a href="https://leetcode.com/problems/check-if-there-is-a-valid-parentheses-string-path">See the problem</a>
    /// </summary>
    public bool HasValidPath(char[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var pathLength = rows + cols - 1;

        // A valid parentheses string has even length, starts with '(', and ends with ')'.
        if ((pathLength & 1) == 1 || grid[0][0] == ')' || grid[rows - 1][cols - 1] == '(')
        {
            return false;
        }

        // reachable[col][balance] stores the states for the cell directly above.
        // While scanning a row, left stores the states for the cell to the left.
        var reachable = new bool[cols][];

        for (var row = 0; row < rows; row++)
        {
            bool[] left = null;

            for (var col = 0; col < cols; col++)
            {
                var current = new bool[pathLength + 1];
                var change = grid[row][col] == '(' ? 1 : -1;
                var remaining = pathLength - row - col - 1;

                if (row == 0 && col == 0)
                {
                    current[1] = true;
                }
                else
                {
                    var above = reachable[col];

                    for (var balance = 0; balance <= pathLength; balance++)
                    {
                        if ((above != null && above[balance]) || (left != null && left[balance]))
                        {
                            var nextBalance = balance + change;

                            // The balance may never be negative and must be closable by
                            // the cells that remain on the path.
                            if (nextBalance >= 0 && nextBalance <= remaining)
                            {
                                current[nextBalance] = true;
                            }
                        }
                    }
                }

                reachable[col] = current;
                left = current;
            }
        }

        return reachable[cols - 1][0];
    }
}

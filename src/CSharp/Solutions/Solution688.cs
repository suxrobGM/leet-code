namespace LeetCode.Solutions;

public class Solution688
{
    /// <summary>
    /// 688. Knight Probability in Chessboard - Medium
    /// <a href="https://leetcode.com/problems/knight-probability-in-chessboard">See the problem</a>
    /// </summary>
    public double KnightProbability(int n, int k, int row, int column)
    {
        // dp[r][c][m] represents the probability of the knight being at (r, c) after m moves
        var dp = new double[n, n, k + 1];

        // Initial position with probability 1
        dp[row, column, 0] = 1.0;

        // Iterate through each move count from 0 to k
        for (var move = 0; move < k; move++)
        {
            // Iterate through all positions on the board
            for (var r = 0; r < n; r++)
            {
                for (var c = 0; c < n; c++)
                {
                    // If there's a probability of being at (r, c) after "move" moves
                    if (dp[r, c, move] > 0)
                    {
                        // Try all possible knight moves
                        foreach (var direction in directions)
                        {
                            var nr = r + direction[0];
                            var nc = c + direction[1];
                            // If the new position (nr, nc) is valid (on the board)
                            if (nr >= 0 && nr < n && nc >= 0 && nc < n)
                            {
                                dp[nr, nc, move + 1] += dp[r, c, move] / 8.0;
                            }
                        }
                    }
                }
            }
        }

        // Sum up all the probabilities of the knight remaining on the board after k moves
        var result = 0.0;
        for (var r = 0; r < n; r++)
        {
            for (var c = 0; c < n; c++)
            {
                result += dp[r, c, k];
            }
        }

        return result;
    }

    private static readonly int[][] directions = [
        [-2, -1], [-1, -2], [1, -2], [2, -1],
        [2, 1], [1, 2], [-1, 2], [-2, 1]
    ];
}

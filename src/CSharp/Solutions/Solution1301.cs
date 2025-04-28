using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1301
{
    /// <summary>
    /// 1301. Number of Paths with Max Score - Hard
    /// <a href="https://leetcode.com/problems/number-of-paths-with-max-score">See the problem</a>
    /// </summary>
    public int[] PathsWithMaxScore(IList<string> board)
    {
        const int MOD = 1_000_000_007;
        int n = board.Count;
        var dp = new (int maxSum, int count)[n, n];

        dp[n - 1, n - 1] = (0, 1); // Start at 'S'

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (board[i][j] == 'X') continue; // obstacle

                if (i == n - 1 && j == n - 1) continue; // starting point

                var candidates = new (int sum, int count)[] {
                    i + 1 < n ? dp[i + 1, j] : (0, 0),
                    j + 1 < n ? dp[i, j + 1] : (0, 0),
                    (i + 1 < n && j + 1 < n) ? dp[i + 1, j + 1] : (0, 0),
                };

                int maxSum = -1;
                foreach (var (sum, count) in candidates)
                {
                    if (count > 0)
                        maxSum = Math.Max(maxSum, sum);
                }

                if (maxSum == -1)
                    continue; // no valid way to reach this cell

                int ways = 0;
                foreach (var (sum, count) in candidates)
                {
                    if (sum == maxSum)
                        ways = (ways + count) % MOD;
                }

                int add = 0;
                if (board[i][j] != 'E')
                    add = board[i][j] - '0';

                dp[i, j] = (maxSum + add, ways);
            }
        }

        var result = dp[0, 0];
        if (result.count == 0)
            return [0, 0];

        return [result.maxSum, result.count];
    }
}

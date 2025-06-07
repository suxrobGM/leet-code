using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1510
{
    /// <summary>
    /// 1510. Stone Game IV - Hard
    /// <a href="https://leetcode.com/problems/stone-game-iv">See the problem</a>
    /// </summary>
    public bool WinnerSquareGame(int n)
    {
        // Create a DP array to store the results for each number of stones
        var dp = new bool[n + 1];

        // Iterate through each number of stones from 1 to n
        for (int i = 1; i <= n; i++)
        {
            // Check all possible square numbers that can be subtracted
            for (int j = 1; j * j <= i; j++)
            {
                if (!dp[i - j * j])
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        // The result for n stones is stored in dp[n]
        return dp[n];
    }
}

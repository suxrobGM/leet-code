using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution935
{
    /// <summary>
    /// 935. Knight Dialer - Medium
    /// <a href="https://leetcode.com/problems/knight-dialer">See the problem</a>
    /// </summary>
    public int KnightDialer(int n)
    {
        const int MOD = 1_000_000_007;

        // Adjacency list for valid knight moves
        int[][] moves = [
            [4, 6],      // From 0
            [6, 8],      // From 1
            [7, 9],      // From 2
            [4, 8],      // From 3
            [0, 3, 9],   // From 4
            [],          // From 5 (invalid)
            [0, 1, 7],   // From 6
            [2, 6],      // From 7
            [1, 3],      // From 8
            [2, 4]       // From 9
        ];

        // DP array: dp[length][digit]
        var dp = new int[n + 1, 10];

        // Base case: at length 1, each digit can be used once
        for (int digit = 0; digit <= 9; digit++)
        {
            dp[1, digit] = 1;
        }

        // Fill DP table for lengths 2 to n
        for (int len = 2; len <= n; len++)
        {
            for (int digit = 0; digit <= 9; digit++)
            {
                foreach (int next in moves[digit])
                {
                    dp[len, digit] = (dp[len, digit] + dp[len - 1, next]) % MOD;
                }
            }
        }

        // Sum up all numbers of length n
        int result = 0;
        for (int digit = 0; digit <= 9; digit++)
        {
            result = (result + dp[n, digit]) % MOD;
        }

        return result;
    }
}

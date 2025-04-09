using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1220
{
    /// <summary>
    /// 1220. Count Vowels Permutation - Hard
    /// <a href="https://leetcode.com/problems/count-vowels-permutation">See the problem</a>
    /// </summary>
    public int CountVowelPermutation(int n)
    {
        const int MOD = 1000000007;
        var dp = new long[5];
        var temp = new long[5];

        // Initialize the base case for n = 1
        for (int i = 0; i < 5; i++)
            dp[i] = 1;

        for (int i = 2; i <= n; i++)
        {
            temp[0] = (dp[1] + dp[2] + dp[4]) % MOD; // 'a'
            temp[1] = (dp[0] + dp[2]) % MOD;       // 'e'
            temp[2] = (dp[1] + dp[3]) % MOD;       // 'i'
            temp[3] = dp[2];                       // 'o'
            temp[4] = (dp[2] + dp[3]) % MOD;       // 'u'

            Array.Copy(temp, dp, 5); // Update dp for the next iteration
        }

        long result = 0;
        foreach (var count in dp)
            result = (result + count) % MOD;

        return (int)result;
    }
}

using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution920
{
    /// <summary>
    /// 920. Number of Music Playlists - Hard
    /// <a href="https://leetcode.com/problems/number-of-music-playlists">See the problem</a>
    /// </summary>
    public int NumMusicPlaylists(int n, int goal, int k)
    {
        var mod = 1000000007;
        var dp = new long[goal + 1, n + 1];
        dp[0, 0] = 1;

        for (var i = 1; i <= goal; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                dp[i, j] = (dp[i - 1, j - 1] * (n - j + 1) + dp[i - 1, j] * Math.Max(j - k, 0)) % mod;
            }
        }
        
        return (int)dp[goal, n];
    }
}

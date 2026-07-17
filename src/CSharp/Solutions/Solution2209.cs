namespace LeetCode.Solutions;

public class Solution2209
{
    /// <summary>
    /// 2209. Minimum White Tiles After Covering With Carpets - Hard
    /// <a href="https://leetcode.com/problems/minimum-white-tiles-after-covering-with-carpets">See the problem</a>
    /// </summary>
    public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen)
    {
        var n = floor.Length;
        var dp = new int[n + 1, numCarpets + 1];

        for (var i = 1; i <= n; i++)
        {
            for (var j = 0; j <= numCarpets; j++)
            {
                // If we don't use a carpet at this position
                dp[i, j] = dp[i - 1, j] + (floor[i - 1] == '1' ? 1 : 0);

                // If we use a carpet at this position
                if (j > 0)
                {
                    var start = Math.Max(0, i - carpetLen);
                    dp[i, j] = Math.Min(dp[i, j], dp[start, j - 1]);
                }
            }
        }

        return dp[n, numCarpets];
    }
}

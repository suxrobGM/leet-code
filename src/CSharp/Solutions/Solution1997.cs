namespace LeetCode.Solutions;

public class Solution1997
{
    /// <summary>
    /// 1997. First Day Where You Have Been in All the Rooms - Medium
    /// <a href="https://leetcode.com/problems/first-day-where-you-have-been-in-all-the-rooms">See the problem</a>
    /// </summary>
    public int FirstDayBeenInAllRooms(int[] nextVisit)
    {
        const int MOD = 1_000_000_007;
        int n = nextVisit.Length;
        long[] dp = new long[n];
        dp[0] = 0;

        for (int i = 1; i < n; i++)
        {
            dp[i] = (2 * dp[i - 1] - dp[nextVisit[i - 1]] + 2 + MOD) % MOD;
        }

        return (int)dp[n - 1];
    }
}

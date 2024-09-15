using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution552
{
    /// <summary>
    /// 552. Student Attendance Record II - Hard
    /// <a href="https://leetcode.com/problems/student-attendance-record-ii">See the problem</a>
    /// </summary>
    public int CheckRecord(int n)
    {
        const int MOD = 1000000007;
        var dp = new long[n + 1, 2, 3];

        dp[1, 0, 0] = 1;
        dp[1, 1, 0] = 1;
        dp[1, 0, 1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i, 0, 0] = (dp[i - 1, 0, 0] + dp[i - 1, 0, 1] + dp[i - 1, 0, 2]) % MOD;
            dp[i, 1, 0] = (dp[i - 1, 0, 0] + dp[i - 1, 0, 1] + dp[i - 1, 0, 2] + dp[i - 1, 1, 0] + dp[i - 1, 1, 1] + dp[i - 1, 1, 2]) % MOD;
            dp[i, 0, 1] = dp[i - 1, 0, 0];
            dp[i, 0, 2] = dp[i - 1, 0, 1];
            dp[i, 1, 1] = dp[i - 1, 1, 0];
            dp[i, 1, 2] = dp[i - 1, 1, 1];
        }

        long result = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result += dp[n, i, j];
            }
        }

        return (int)(result % MOD);
    }
}

using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1937
{
    /// <summary>
    /// 1937. Maximum Number of Points with Cost - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-points-with-cost">See the problem</a>
    /// </summary>
    public long MaxPoints(int[][] points)
    {
        int m = points.Length;
        int n = points[0].Length;
        long[] dp = new long[n];

        for (int i = 0; i < m; i++)
        {
            long[] newDp = new long[n];
            long[] leftMax = new long[n];
            long[] rightMax = new long[n];

            leftMax[0] = dp[0];
            for (int j = 1; j < n; j++)
            {
                leftMax[j] = Math.Max(leftMax[j - 1] - 1, dp[j]);
            }

            rightMax[n - 1] = dp[n - 1];
            for (int j = n - 2; j >= 0; j--)
            {
                rightMax[j] = Math.Max(rightMax[j + 1] - 1, dp[j]);
            }

            for (int j = 0; j < n; j++)
            {
                newDp[j] = points[i][j] + Math.Max(leftMax[j], rightMax[j]);
            }

            dp = newDp;
        }

        long maxPoints = 0;
        foreach (var val in dp)
        {
            maxPoints = Math.Max(maxPoints, val);
        }

        return maxPoints;
    }
}

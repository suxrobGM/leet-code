using System.Text;


namespace LeetCode.Solutions;

public class Solution1691
{
    /// <summary>
    /// 1691. Maximum Height by Stacking Cuboids - Hard
    /// <a href="https://leetcode.com/problems/maximum-height-by-stacking-cuboids">See the problem</a>
    /// </summary>
    public int MaxHeight(int[][] cuboids)
    {
        // Step 1: Normalize the cuboid dimensions
        foreach (var cuboid in cuboids)
            Array.Sort(cuboid); // sort width, length, height

        // Step 2: Sort all cuboids globally
        Array.Sort(cuboids, (a, b) =>
        {
            if (a[0] != b[0]) return a[0] - b[0];
            if (a[1] != b[1]) return a[1] - b[1];
            return a[2] - b[2];
        });

        int n = cuboids.Length;
        int[] dp = new int[n];
        int maxHeight = 0;

        // Step 3: DP to calculate max stacking height
        for (int i = 0; i < n; i++)
        {
            dp[i] = cuboids[i][2]; // height as starting point
            for (int j = 0; j < i; j++)
            {
                if (CanStack(cuboids[j], cuboids[i]))
                {
                    dp[i] = Math.Max(dp[i], dp[j] + cuboids[i][2]);
                }
            }
            maxHeight = Math.Max(maxHeight, dp[i]);
        }

        return maxHeight;
    }

    private bool CanStack(int[] bottom, int[] top)
    {
        return bottom[0] <= top[0] && bottom[1] <= top[1] && bottom[2] <= top[2];
    }
}

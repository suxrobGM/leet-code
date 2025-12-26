using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1959
{
    /// <summary>
    /// 1959. Minimum Total Space Wasted With K Resizing Operations - Medium
    /// <a href="https://leetcode.com/problems/minimum-total-space-wasted-with-k-resizing-operations">See the problem</a>
    /// </summary>
    public int MinSpaceWastedKResizing(int[] nums, int k)
    {
        int n = nums.Length;

        // dp[i][j] = minimum waste for nums[0...i-1] using exactly j segments
        // We can use at most k+1 segments (k resizing operations)
        var dp = new int[n + 1, k + 2];

        // Initialize with maximum values (invalid states)
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= k + 1; j++)
            {
                dp[i, j] = int.MaxValue;
            }
        }

        // Base case: 0 elements with 0 segments requires 0 waste
        dp[0, 0] = 0;

        // Fill DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= Math.Min(i, k + 1); j++)
            {
                // Try all possible starting points for the j-th segment
                // The j-th segment must start at index >= j-1 (need space for j-1 elements before it)
                for (int start = j - 1; start < i; start++)
                {
                    if (dp[start, j - 1] != int.MaxValue)
                    {
                        int waste = ComputeWaste(nums, start, i - 1);
                        dp[i, j] = Math.Min(dp[i, j], dp[start, j - 1] + waste);
                    }
                }
            }
        }

        // Find minimum waste using at most k+1 segments
        int result = int.MaxValue;
        for (int j = 1; j <= k + 1; j++)
        {
            result = Math.Min(result, dp[n, j]);
        }

        return result;
    }

    /// <summary>
    /// Compute the total waste if we cover nums[start...end] with one segment.
    /// The segment size must be max(nums[start...end]).
    /// Waste = sum of (max - nums[i]) for all i in [start, end]
    /// </summary>
    private int ComputeWaste(int[] nums, int start, int end)
    {
        // Find maximum value in the range
        int maxVal = nums[start];
        for (int i = start; i <= end; i++)
        {
            maxVal = Math.Max(maxVal, nums[i]);
        }

        // Calculate total waste
        long waste = 0;
        for (int i = start; i <= end; i++)
        {
            waste += maxVal - nums[i];
        }

        return (int)waste;
    }
}

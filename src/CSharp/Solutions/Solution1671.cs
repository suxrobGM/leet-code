using System.Text;


namespace LeetCode.Solutions;

public class Solution1671
{
    /// <summary>
    /// 1671. Minimum Number of Removals to Make Mountain Array - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-removals-to-make-mountain-array">See the problem</a>
    /// </summary>
    public int MinimumMountainRemovals(int[] nums)
    {
        int n = nums.Length;
        int[] left = new int[n];
        int[] right = new int[n];

        // Compute LIS ending at each index
        for (int i = 0; i < n; i++)
        {
            left[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                    left[i] = Math.Max(left[i], left[j] + 1);
            }
        }

        // Compute LDS starting at each index
        for (int i = n - 1; i >= 0; i--)
        {
            right[i] = 1;
            for (int j = n - 1; j > i; j--)
            {
                if (nums[j] < nums[i])
                    right[i] = Math.Max(right[i], right[j] + 1);
            }
        }

        int maxMountain = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if (left[i] >= 2 && right[i] >= 2)
            {
                maxMountain = Math.Max(maxMountain, left[i] + right[i] - 1);
            }
        }

        return n - maxMountain;
    }
}

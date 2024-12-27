using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution915
{
    /// <summary>
    /// 915. Partition Array into Disjoint Intervals - Medium
    /// <a href="https://leetcode.com/problems/partition-array-into-disjoint-intervals">See the problem</a>
    /// </summary>
    public int PartitionDisjoint(int[] nums)
    {
        var n = nums.Length;
        var leftMax = new int[n];
        var rightMin = new int[n];

        leftMax[0] = nums[0];
        for (var i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
        }

        rightMin[n - 1] = nums[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            rightMin[i] = Math.Min(rightMin[i + 1], nums[i]);
        }

        for (var i = 1; i < n; i++)
        {
            if (leftMax[i - 1] <= rightMin[i])
            {
                return i;
            }
        }

        return -1;
    }
}

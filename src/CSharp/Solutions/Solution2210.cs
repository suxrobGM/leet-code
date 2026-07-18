namespace LeetCode.Solutions;

public class Solution2210
{
    /// <summary>
    /// 2210. Count Hills and Valleys in an Array - Easy
    /// <a href="https://leetcode.com/problems/count-hills-and-valleys-in-an-array">See the problem</a>
    /// </summary>
    public int CountHillValley(int[] nums)
    {
        var count = 0;

        // Track the last value that differs from the current one.
        var left = nums[0];

        for (var i = 1; i < nums.Length - 1; i++)
        {
            // Skip plateaus: equal neighbors are part of the same hill/valley.
            if (nums[i] == nums[i + 1])
            {
                continue;
            }

            var isHill = nums[i] > left && nums[i] > nums[i + 1];
            var isValley = nums[i] < left && nums[i] < nums[i + 1];

            if (isHill || isValley)
            {
                count++;
            }

            left = nums[i];
        }

        return count;
    }
}

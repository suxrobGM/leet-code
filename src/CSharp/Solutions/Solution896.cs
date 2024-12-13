using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution896
{
    /// <summary>
    /// 896. Monotonic Array - Easy
    /// <a href="https://leetcode.com/problems/monotonic-array">See the problem</a>
    /// </summary>
    public bool IsMonotonic(int[] nums)
    {
        var increasing = true;
        var decreasing = true;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                decreasing = false;
            }
            else if (nums[i] < nums[i - 1])
            {
                increasing = false;
            }
        }

        return increasing || decreasing;
    }
}

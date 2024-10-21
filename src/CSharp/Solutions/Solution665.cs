using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution665
{
    /// <summary>
    /// 665. Non-decreasing Array - Medium
    /// <a href="https://leetcode.com/problems/non-decreasing-array">See the problem</a>
    /// </summary>
    public bool CheckPossibility(int[] nums)
    {
        var count = 0;

        for (var i = 1; i < nums.Length && count <= 1; i++)
        {
            if (nums[i - 1] > nums[i])
            {
                count++;

                if (i - 2 < 0 || nums[i - 2] <= nums[i])
                {
                    nums[i - 1] = nums[i];
                }
                else
                {
                    nums[i] = nums[i - 1];
                }
            }
        }

        return count <= 1;
    }
}

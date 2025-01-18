using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution945
{
    /// <summary>
    /// 945. Minimum Increment to Make Array Unique - Medium
    /// <a href="https://leetcode.com/problems/minimum-increment-to-make-array-unique">See the problem</a>
    /// </summary>
    public int MinIncrementForUnique(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int count = 0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                count += nums[i - 1] - nums[i] + 1;
                nums[i] = nums[i - 1] + 1;
            }
        }

        return count;
    }
}

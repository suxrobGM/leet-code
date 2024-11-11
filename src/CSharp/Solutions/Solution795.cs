
namespace LeetCode.Solutions;

public class Solution795
{
    /// <summary>
    /// 795. Number of Subarrays with Bounded Maximum - Medium
    /// <a href="https://leetcode.com/problems/number-of-subarrays-with-bounded-maximum">See the problem</a>
    /// </summary>
    public int NumSubarrayBoundedMax(int[] nums, int left, int right)
    {
        var result = 0;
        var start = -1;
        var end = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > right)
            {
                start = i;
            }

            if (nums[i] >= left)
            {
                end = i;
            }

            result += end - start;
        }

        return result;
    }
}

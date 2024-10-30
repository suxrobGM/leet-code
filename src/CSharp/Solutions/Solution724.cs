using System.Text;

namespace LeetCode.Solutions;

public class Solution724
{
    /// <summary>
    /// 724. Find Pivot Index - Easy
    /// <a href="https://leetcode.com/problems/find-pivot-index">See the problem</a>
    /// </summary>
    public int PivotIndex(int[] nums)
    {
        var totalSum = 0;
        var leftSum = 0;

        foreach (var num in nums)
        {
            totalSum += num;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (leftSum == totalSum - leftSum - nums[i])
            {
                return i;
            }

            leftSum += nums[i];
        }

        return -1;
    }
}

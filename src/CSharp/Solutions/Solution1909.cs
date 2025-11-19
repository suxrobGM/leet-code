using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1909
{
    /// <summary>
    /// 1909. Remove One Element to Make the Array Strictly Increasing - Easy
    /// <a href="https://leetcode.com/problems/remove-one-element-to-make-the-array-strictly-increasing">See the problem</a>
    /// </summary>
    public bool CanBeIncreasing(int[] nums)
    {
        int n = nums.Length;
        int count = 0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                count++;
                if (count > 1)
                {
                    return false;
                }

                if (i == 1 || nums[i] > nums[i - 2])
                {
                    // Remove nums[i - 1]
                    continue;
                }
                else if (i == n - 1 || nums[i + 1] > nums[i - 1])
                {
                    // Remove nums[i]
                    continue;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}

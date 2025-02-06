using System.Numerics;
using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution976
{
    /// <summary>
    /// 976. Largest Perimeter Triangle - Easy
    /// <a href="https://leetcode.com/problems/largest-perimeter-triangle">See the problem</a>
    /// </summary>
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;

        for (int i = n - 1; i >= 2; i--)
        {
            if (nums[i - 2] + nums[i - 1] > nums[i])
                return nums[i - 2] + nums[i - 1] + nums[i];
        }

        return 0;
    }
}

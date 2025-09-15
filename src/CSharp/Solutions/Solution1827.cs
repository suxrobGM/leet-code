using System.Text;

namespace LeetCode.Solutions;

public class Solution1827
{
    /// <summary>
    /// 1827. Minimum Operations to Make the Array Increasing - Easy
    /// <a href="https://leetcode.com/problems/minimum-operations-to-make-the-array-increasing">See the problem</a>
    /// </summary>
    public int MinOperations(int[] nums)
    {
        int operations = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                int needed = nums[i - 1] - nums[i] + 1;
                operations += needed;
                nums[i] += needed;
            }
        }
        return operations;
    }

}

using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1887
{
    /// <summary>
    /// 1887. Reduction Operations to Make the Array Elements Equal - Medium
    /// <a href="https://leetcode.com/problems/reduction-operations-to-make-the-array-elements-equal">See the problem</a>
    /// </summary>
    public int ReductionOperations(int[] nums)
    {
        Array.Sort(nums);
        int operations = 0;
        int currentLevel = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                currentLevel++;
            }
            operations += currentLevel;
        }

        return operations;
    }
}

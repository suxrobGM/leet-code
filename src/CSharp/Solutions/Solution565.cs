using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution565
{
    /// <summary>
    /// 565. Array Nesting - Medium
    /// <a href="https://leetcode.com/problems/array-nesting">See the problem</a>
    /// </summary>
    public int ArrayNesting(int[] nums)
    {
        var max = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                continue;
            }

            var count = 0;
            var j = i;
            while (nums[j] >= 0)
            {
                var next = nums[j];
                nums[j] = -1;
                j = next;
                count++;
            }

            max = Math.Max(max, count);
        }

        return max;
    }
}

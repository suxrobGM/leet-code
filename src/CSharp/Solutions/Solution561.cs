using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution561
{
    /// <summary>
    /// 561. Array Partition I - Easy
    /// <a href="https://leetcode.com/problems/array-partition-i">See the problem</a>
    /// </summary>
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);
        var sum = 0;
        for (var i = 0; i < nums.Length; i += 2)
        {
            sum += nums[i];
        }

        return sum;
    }
}

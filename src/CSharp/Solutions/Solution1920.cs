using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1920
{
    /// <summary>
    /// 1920. Build Array from Permutation - Easy
    /// <a href="https://leetcode.com/problems/build-array-from-permutation">See the problem</a>
    /// </summary>
    public int[] BuildArray(int[] nums)
    {
        var n = nums.Length;
        var result = new int[n];

        for (var i = 0; i < n; i++)
        {
            result[i] = nums[nums[i]];
        }

        return result;
    }
}

using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1929
{
    /// <summary>
    /// 1929. Concatenation of Array - Easy
    /// <a href="https://leetcode.com/problems/concatenation-of-array">See the problem</a>
    /// </summary>
    public int[] GetConcatenation(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[2 * n];

        for (int i = 0; i < n; i++)
        {
            result[i] = nums[i];
            result[i + n] = nums[i];
        }

        return result;
    }
}

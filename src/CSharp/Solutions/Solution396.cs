using System.Text;

namespace LeetCode.Solutions;

public class Solution396
{
    /// <summary>
    /// 396. Rotate Function - Medium
    /// <a href="https://leetcode.com/problems/rotate-function">See the problem</a>
    /// </summary>
    public int MaxRotateFunction(int[] nums)
    {
        var sum = 0;
        var f = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            f += i * nums[i];
        }

        var result = f;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            f += sum - nums.Length * nums[i];
            result = Math.Max(result, f);
        }

        return result;
    }
}

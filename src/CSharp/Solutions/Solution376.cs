namespace LeetCode.Solutions;

public class Solution376
{
    /// <summary>
    /// 376. Wiggle Subsequence - Medium
    /// <a href="https://leetcode.com/problems/wiggle-subsequence">See the problem</a>
    /// </summary>
    public int WiggleMaxLength(int[] nums)
    {
        if (nums.Length < 2)
        {
            return nums.Length;
        }

        var up = 1;
        var down = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                up = down + 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                down = up + 1;
            }
        }

        return Math.Max(up, down);
    }
}

namespace LeetCode.Solutions;

public class Solution2256
{
    /// <summary>
    /// 2256. Minimum Average Difference - Medium
    /// <a href="https://leetcode.com/problems/minimum-average-difference">See the problem</a>
    /// </summary>
    public int MinimumAverageDifference(int[] nums)
    {
        var n = nums.Length;
        var total = 0L;

        foreach (var num in nums)
        {
            total += num;
        }

        var index = 0;
        var minDifference = long.MaxValue;
        var prefix = 0L;

        for (var i = 0; i < n; i++)
        {
            prefix += nums[i];
            var left = prefix / (i + 1);
            var right = i == n - 1 ? 0 : (total - prefix) / (n - 1 - i);
            var difference = Math.Abs(left - right);

            if (difference < minDifference)
            {
                minDifference = difference;
                index = i;
            }
        }

        return index;
    }
}

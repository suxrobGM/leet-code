namespace LeetCode.Solutions;

public class Solution2270
{
    /// <summary>
    /// 2270. Number of Ways to Split Array - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-split-array">See the problem</a>
    /// </summary>
    public int WaysToSplitArray(int[] nums)
    {
        var total = 0L;

        foreach (var num in nums)
        {
            total += num;
        }

        var left = 0L;
        var validSplits = 0;

        // The last element can never start the right half, so stop before it.
        for (var i = 0; i < nums.Length - 1; i++)
        {
            left += nums[i];

            if (left >= total - left)
            {
                validSplits++;
            }
        }

        return validSplits;
    }
}

using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution673
{
    /// <summary>
    /// 673. Number of Longest Increasing Subsequence - Medium
    /// <a href="https://leetcode.com/problems/number-of-longest-increasing-subsequence">See the problem</a>
    /// </summary>
    public int FindNumberOfLIS(int[] nums)
    {
        var n = nums.Length;
        var lengths = new int[n];
        var counts = new int[n];

        var maxLength = 0;
        var result = 0;

        for (var i = 0; i < n; i++)
        {
            lengths[i] = 1;
            counts[i] = 1;

            for (var j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    if (lengths[j] + 1 > lengths[i])
                    {
                        lengths[i] = lengths[j] + 1;
                        counts[i] = counts[j];
                    }
                    else if (lengths[j] + 1 == lengths[i])
                    {
                        counts[i] += counts[j];
                    }
                }
            }

            if (lengths[i] > maxLength)
            {
                maxLength = lengths[i];
                result = counts[i];
            }
            else if (lengths[i] == maxLength)
            {
                result += counts[i];
            }
        }

        return result;
    }
}

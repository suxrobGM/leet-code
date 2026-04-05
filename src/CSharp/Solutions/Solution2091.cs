namespace LeetCode.Solutions;

public class Solution2091
{
    /// <summary>
    /// 2091. Removing Minimum and Maximum From Array - Medium
    /// <a href="https://leetcode.com/problems/removing-minimum-and-maximum-from-array">See the problem</a>
    /// </summary>
    public int MinimumDeletions(int[] nums)
    {
        var n = nums.Length;
        int minIdx = 0, maxIdx = 0;

        for (var i = 1; i < n; i++)
        {
            if (nums[i] < nums[minIdx]) minIdx = i;
            if (nums[i] > nums[maxIdx]) maxIdx = i;
        }

        var left = Math.Max(minIdx, maxIdx) + 1;          // remove both from front
        var right = n - Math.Min(minIdx, maxIdx);          // remove both from back
        var both = Math.Min(minIdx, maxIdx) + 1            // smaller index from front
                 + n - Math.Max(minIdx, maxIdx);           // larger index from back

        return Math.Min(left, Math.Min(right, both));
    }
}

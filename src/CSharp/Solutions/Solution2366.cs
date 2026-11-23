namespace LeetCode.Solutions;

public class Solution2366
{
    /// <summary>
    /// 2366. Minimum Replacements to Sort the Array - Hard
    /// <a href="https://leetcode.com/problems/minimum-replacements-to-sort-the-array">See the problem</a>
    /// </summary>
    public long MinimumReplacement(int[] nums)
    {
        long replacements = 0;
        int maxAllowed = nums[^1];

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            int value = nums[i];
            int parts = (value - 1) / maxAllowed + 1;
            replacements += parts - 1;

            // Splitting as evenly as possible maximizes the smallest part.
            maxAllowed = value / parts;
        }

        return replacements;
    }
}

namespace LeetCode.Solutions;

public class Solution2057
{
    /// <summary>
    /// 2057. Smallest Index With Equal Value - Easy
    /// <a href="https://leetcode.com/problems/smallest-index-with-equal-value">See the problem</a>
    /// </summary>
    public int SmallestEqual(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (i % 10 == nums[i]) return i;
        }

        return -1;
    }
}

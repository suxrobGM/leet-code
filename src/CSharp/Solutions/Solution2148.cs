namespace LeetCode.Solutions;

public class Solution2148
{
    /// <summary>
    /// 2148. Count Elements With Strictly Smaller and Greater Elements - Easy
    /// <a href="https://leetcode.com/problems/count-elements-with-strictly-smaller-and-greater-elements">See the problem</a>
    /// </summary>
    public int CountElements(int[] nums)
    {
        int min = int.MaxValue, max = int.MinValue;
        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        if (min == max) return 0;

        int count = 0;
        foreach (var num in nums)
        {
            if (num > min && num < max) count++;
        }
        return count;
    }
}

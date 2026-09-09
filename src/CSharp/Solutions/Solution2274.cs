namespace LeetCode.Solutions;

public class Solution2274
{
    /// <summary>
    /// 2274. Maximum Consecutive Floors Without Special Floors - Medium
    /// <a href="https://leetcode.com/problems/maximum-consecutive-floors-without-special-floors">See the problem</a>
    /// </summary>
    public int MaxConsecutive(int bottom, int top, int[] special)
    {
        if (special.Length == 0)
        {
            return top - bottom + 1;
        }

        Array.Sort(special);

        var maximum = Math.Max(special[0] - bottom, top - special[^1]);

        for (var i = 1; i < special.Length; i++)
        {
            maximum = Math.Max(maximum, special[i] - special[i - 1] - 1);
        }

        return maximum;
    }
}

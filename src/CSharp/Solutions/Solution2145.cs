namespace LeetCode.Solutions;

public class Solution2145
{
    /// <summary>
    /// 2145. Count the Hidden Sequences - Medium
    /// <a href="https://leetcode.com/problems/count-the-hidden-sequences">See the problem</a>
    /// </summary>
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        long prefix = 0, min = 0, max = 0;
        foreach (int d in differences)
        {
            prefix += d;
            min = Math.Min(min, prefix);
            max = Math.Max(max, prefix);
        }
        long count = upper - lower - (max - min) + 1;
        return (int)Math.Max(0, count);
    }
}

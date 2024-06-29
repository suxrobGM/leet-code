using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution233
{
    /// <summary>
    /// 233. Number of Digit One - Hard
    /// <a href="https://leetcode.com/problems/number-of-digit-one">See the problem</a>
    /// </summary>
    public int CountDigitOne(int n)
    {
        var count = 0;
        var factor = 1;

        while (factor <= n)
        {
            var divider = factor * 10;
            count += (n / divider) * factor + Math.Min(Math.Max(n % divider - factor + 1, 0), factor);
            factor *= 10;
        }

        return count;
    }
}

namespace LeetCode.Solutions;

public class Solution264
{
    /// <summary>
    /// 264. Ugly Number II - Medium
    /// <a href="https://leetcode.com/problems/ugly-number-ii">See the problem</a>
    /// </summary>
    public int NthUglyNumber(int n)
    {
        var uglyNumbers = new int[n];
        uglyNumbers[0] = 1;

        var i2 = 0;
        var i3 = 0;
        var i5 = 0;

        for (var i = 1; i < n; i++)
        {
            var nextUglyNumber = Math.Min(uglyNumbers[i2] * 2, Math.Min(uglyNumbers[i3] * 3, uglyNumbers[i5] * 5));
            uglyNumbers[i] = nextUglyNumber;

            if (nextUglyNumber == uglyNumbers[i2] * 2)
            {
                i2++;
            }

            if (nextUglyNumber == uglyNumbers[i3] * 3)
            {
                i3++;
            }

            if (nextUglyNumber == uglyNumbers[i5] * 5)
            {
                i5++;
            }
        }

        return uglyNumbers[n - 1];
    }
}

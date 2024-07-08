using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution343
{
    /// <summary>
    /// 343. Integer Break - Medium
    /// <a href="https://leetcode.com/problems/integer-break">See the problem</a>
    /// </summary>
    public int IntegerBreak(int n)
    {
        if (n == 2)
        {
            return 1;
        }

        if (n == 3)
        {
            return 2;
        }

        var result = 1;

        while (n > 4)
        {
            result *= 3;
            n -= 3;
        }

        return result * n;
    }
}

using System.Numerics;

namespace LeetCode.Solutions;

public class Solution2119
{
    /// <summary>
    /// 2119. A Number After a Double Reversal - Easy
    /// <a href="https://leetcode.com/problems/a-number-after-a-double-reversal">See the problem</a>
    /// </summary>
    public bool IsSameAfterReversals(int num)
    {
        if (num == 0)
        {
            return true;
        }

        return num % 10 != 0;
    }
}

using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1009
{
    /// <summary>
    /// 1009. Complement of Base 10 Integer - Easy
    /// <a href="https://leetcode.com/problems/complement-of-base-10-integer</a>
    /// </summary>
    public int BitwiseComplement(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        var mask = 1;
        while (mask < n)
        {
            mask = (mask << 1) | 1;
        }

        return ~n & mask;
    }
}

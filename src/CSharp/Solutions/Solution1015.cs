using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1015
{
    /// <summary>
    /// 1015. Smallest Integer Divisible by K - Medium
    /// <a href="https://leetcode.com/problems/smallest-integer-divisible-by-k</a>
    /// </summary>
    public int SmallestRepunitDivByK(int k)
    {
        if (k % 2 == 0 || k % 5 == 0)
        {
            return -1;
        }

        var remainder = 0;
        for (var length = 1; length <= k; length++)
        {
            remainder = (remainder * 10 + 1) % k;
            if (remainder == 0)
            {
                return length;
            }
        }

        return -1;
    }
}

using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution342
{
    /// <summary>
    /// 342. Power of Four - Easy
    /// <a href="https://leetcode.com/problems/power-of-four">See the problem</a>
    /// </summary>
    public bool IsPowerOfFour(int n)
    {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
    }
}

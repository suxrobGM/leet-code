using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution231
{
    /// <summary>
    /// 231. Power of Two - Easy
    /// <a href="https://leetcode.com/problems/power-of-two">See the problem</a>
    /// </summary>
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }
}

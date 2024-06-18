namespace LeetCode.Solutions;

public class Solution190
{
    /// <summary>
    /// 190. Reverse Bits - Easy
    /// <a href="https://leetcode.com/problems/reverse-bits">See the problem</a>
    /// </summary>
    public uint reverseBits(uint n)
    {
        uint result = 0;
        for (var i = 0; i < 32; i++)
        {
            result <<= 1;
            result |= n & 1;
            n >>= 1;
        }
        return result;
    }
}

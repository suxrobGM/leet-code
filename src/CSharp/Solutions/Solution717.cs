using System.Text;

namespace LeetCode.Solutions;

public class Solution717
{
    /// <summary>
    /// 717. 1-bit and 2-bit Characters - Easy
    /// <a href="https://leetcode.com/problems/1-bit-and-2-bit-characters">See the problem</a>
    /// </summary>
    public bool IsOneBitCharacter(int[] bits)
    {
        var n = bits.Length;
        var i = 0;

        while (i < n - 1)
        {
            i += bits[i] + 1;
        }

        return i == n - 1;
    }
}

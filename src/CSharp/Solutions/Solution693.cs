using System.Text;

namespace LeetCode.Solutions;

public class Solution693
{
    /// <summary>
    /// 693. Binary Number with Alternating Bits - Easy
    /// <a href="https://leetcode.com/problems/binary-number-with-alternating-bits">See the problem</a>
    /// </summary>
    public bool HasAlternatingBits(int n)
    {
        var binary = new StringBuilder();
        while (n > 0)
        {
            binary.Insert(0, n % 2);
            n /= 2;
        }

        for (var i = 1; i < binary.Length; i++)
        {
            if (binary[i] == binary[i - 1])
            {
                return false;
            }
        }

        return true;
    }
}

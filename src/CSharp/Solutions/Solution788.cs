using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution788
{
    /// <summary>
    /// 788. Rotated Digits - Medium
    /// <a href="https://leetcode.com/problems/rotated-digits">See the problem</a>
    /// </summary>
    public int RotatedDigits(int n)
    {
        var count = 0;
        for (var i = 1; i <= n; i++)
        {
            if (IsGoodNumber(i))
            {
                count++;
            }
        }

        return count;
    }

    private bool IsGoodNumber(int n)
    {
        var good = false;
        while (n > 0)
        {
            var digit = n % 10;
            if (digit == 3 || digit == 4 || digit == 7)
            {
                return false;
            }

            if (digit == 2 || digit == 5 || digit == 6 || digit == 9)
            {
                good = true;
            }

            n /= 10;
        }

        return good;
    }
}

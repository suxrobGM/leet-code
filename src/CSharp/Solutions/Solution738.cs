using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution738
{
    /// <summary>
    /// 738. Monotone Increasing Digits - Medium
    /// <a href="https://leetcode.com/problems/monotone-increasing-digits">See the problem</a>
    /// </summary>
    public int MonotoneIncreasingDigits(int n)
    {
        var digits = n.ToString().ToCharArray();
        var marker = digits.Length;

        for (var i = digits.Length - 1; i > 0; i--)
        {
            if (digits[i] < digits[i - 1])
            {
                marker = i - 1;
                digits[i - 1]--;
            }
        }

        for (var i = marker + 1; i < digits.Length; i++)
        {
            digits[i] = '9';
        }

        return int.Parse(new string(digits));
    }
}

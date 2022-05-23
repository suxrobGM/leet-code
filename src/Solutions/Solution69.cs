using System.Text;

namespace LeetCode.Solutions;

public partial class Solution
{
    /// <summary>
    /// Given a non-negative integer x, compute and return the square root of x.
    /// Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
    /// Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
    /// <see href="https://leetcode.com/problems/sqrtx/">See the problem</see>
    /// </summary>
    public int MySqrt(int x)
    {
        int first = 0;
        int last = x;
        long temp = 0;

        while (first <= last)
        {
            long mid = (first + last) / 2;
            temp = mid * mid;
            if (x == temp)
            {
                return (int)mid;
            }
            else if (temp > x)
            {
                last = (int)(mid - 1);
            }
            else
            {
                first = (int)(mid + 1);
            }
        }
        return last;
    }
}

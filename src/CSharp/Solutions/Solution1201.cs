using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1201
{
    /// <summary>
    /// 1201. Ugly Number III - Medium
    /// <a href="https://leetcode.com/problems/ugly-number-iii">See the problem</a>
    /// </summary>
    public int NthUglyNumber(int n, int a, int b, int c)
    {
        var lcmAB = LCM(a, b);
        var lcmAC = LCM(a, c);
        var lcmBC = LCM(b, c);
        var lcmABC = LCM(lcmAB, c);

        var left = 1;
        var right = int.MaxValue;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (CountUglyNumbers(mid, a, b, c) < n)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }

    private static long CountUglyNumbers(long x, long a, long b, long c)
    {
        return x / a + x / b + x / c - x / LCM(a, b) - x / LCM(a, c) - x / LCM(b, c) + x / LCM(a, LCM(b, c));
    }

    private static long GCD(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long LCM(long a, long b)
    {
        return a / GCD(a, b) * b;
    }
}

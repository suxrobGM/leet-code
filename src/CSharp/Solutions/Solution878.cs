using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution878
{
    /// <summary>
    /// 878. Nth Magical Number - Hard
    /// <a href="https://leetcode.com/problems/nth-magical-number">See the problem</a>
    /// </summary>
    public int NthMagicalNumber(int n, int a, int b)
    {
        int mod = 1_000_000_007;
        long lcm = (long)a * b / Gcd(a, b);
        long left = 2;
        long right = (long)1e14;

        while (left < right)
        {
            long mid = left + (right - left) / 2;
            long count = mid / a + mid / b - mid / lcm;

            if (count < n)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return (int)(left % mod);
    }

    private long Gcd(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}

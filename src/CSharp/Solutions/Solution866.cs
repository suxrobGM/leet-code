using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution866
{
    /// <summary>
    /// 866. Prime Palindrome - Medium
    /// <a href="https://leetcode.com/problems/prime-palindrome">See the problem</a>
    /// </summary>
    public int PrimePalindrome(int n)
    {
        while (true)
        {
            if (n == Reverse(n) && IsPrime(n))
            {
                return n;
            }

            n++;
            if (10000000 < n && n < 100000000)
            {
                n = 100000000;
            }
        }
    }

    private int Reverse(int n)
    {
        int result = 0;
        while (n > 0)
        {
            result = result * 10 + n % 10;
            n /= 10;
        }

        return result;
    }

    private bool IsPrime(int n)
    {
        if (n < 2)
        {
            return false;
        }

        int sqrt = (int)Math.Sqrt(n);
        for (int i = 2; i <= sqrt; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

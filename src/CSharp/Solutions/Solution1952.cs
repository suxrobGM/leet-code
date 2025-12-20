using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1952
{
    /// <summary>
    /// 1952. Three Divisors - Easy
    /// <a href="https://leetcode.com/problems/three-divisors">See the problem</a>
    /// </summary>
    public bool IsThree(int n)
    {
        if (n < 4) return false;

        int sqrtN = (int)Math.Sqrt(n);
        if (sqrtN * sqrtN != n) return false;

        for (int i = 2; i * i <= sqrtN; i++)
        {
            if (sqrtN % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

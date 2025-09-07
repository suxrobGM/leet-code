using System.Text;

namespace LeetCode.Solutions;

public class Solution1808
{
    /// <summary>
    /// 1808. Maximize Number of Nice Divisors - Hard
    /// <a href="https://leetcode.com/problems/maximize-number-of-nice-divisors">See the problem</a>
    /// </summary>
    public int MaxNiceDivisors(int primeFactors)
    {
        const int MOD = 1_000_000_007;
        if (primeFactors <= 3) return primeFactors;

        long exp = primeFactors / 3;
        int rem = primeFactors % 3;

        if (rem == 0)
        {
            return (int)Pow(3, exp, MOD);
        }
        else if (rem == 1)
        {
            return (int)(Pow(3, exp - 1, MOD) * 4 % MOD);
        }
        else
        { // rem == 2
            return (int)(Pow(3, exp, MOD) * 2 % MOD);
        }
    }

    private long Pow(long a, long b, long mod)
    {
        long res = 1;
        long baseVal = a % mod;
        while (b > 0)
        {
            if ((b & 1) == 1) res = res * baseVal % mod;
            baseVal = baseVal * baseVal % mod;
            b >>= 1;
        }
        return res;
    }
}


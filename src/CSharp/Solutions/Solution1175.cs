using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1175
{
    /// <summary>
    /// 1175. Prime Arrangements - Medium
    /// <a href="https://leetcode.com/problems/prime-arrangements">See the problem</a>
    /// </summary>
    public int NumPrimeArrangements(int n)
    {
        if (n == 1) return 1; // Special case for n = 1

        int primeCount = CountPrimes(n);
        long result = Factorial(primeCount) * Factorial(n - primeCount) % 1000000007;
        return (int)result;
    }

    private int CountPrimes(int n)
    {
        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
            isPrime[i] = true;

        for (int p = 2; p * p <= n; p++)
        {
            if (isPrime[p])
            {
                for (int multiple = p * p; multiple <= n; multiple += p)
                    isPrime[multiple] = false;
            }
        }

        int count = 0;
        for (int i = 2; i <= n; i++)
            if (isPrime[i]) count++;

        return count;
    }

    private long Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
            result = result * i % 1000000007;
        return result;
    }
}

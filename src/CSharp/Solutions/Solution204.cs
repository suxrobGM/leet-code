using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution204
{
    /// <summary>
    /// 204. Count Primes - Medium
    /// <a href="https://leetcode.com/problems/count-primes">See the problem</a>
    /// </summary>
    public int CountPrimes(int n)
    {
        var isPrime = new bool[n];
        for (var i = 2; i < n; i++)
        {
            isPrime[i] = true;
        }

        for (var i = 2; i * i < n; i++)
        {
            if (!isPrime[i])
            {
                continue;
            }

            for (var j = i * i; j < n; j += i)
            {
                isPrime[j] = false;
            }
        }

        var count = 0;
        for (var i = 2; i < n; i++)
        {
            if (isPrime[i])
            {
                count++;
            }
        }

        return count;
    }
}

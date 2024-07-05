namespace LeetCode.Solutions;

public class Solution313
{
    /// <summary>
    /// 313. Super Ugly Number - Medium
    /// <a href="https://leetcode.com/problems/super-ugly-number">See the problem</a>
    /// </summary>
    public int NthSuperUglyNumber(int n, int[] primes)
    {
        var uglyNumbers = new int[n];
        var indices = new int[primes.Length];
        var nextMultiple = new int[primes.Length];

        uglyNumbers[0] = 1;
        
        for (var i = 0; i < primes.Length; i++)
        {
            nextMultiple[i] = primes[i];
        }

        for (var i = 1; i < n; i++)
        {
            var nextUglyNumber = int.MaxValue;
            for (var j = 0; j < primes.Length; j++)
            {
                nextUglyNumber = Math.Min(nextUglyNumber, nextMultiple[j]);
            }
            uglyNumbers[i] = nextUglyNumber;

            for (var j = 0; j < primes.Length; j++)
            {
                if (nextUglyNumber == nextMultiple[j])
                {
                    indices[j]++;
                    nextMultiple[j] = uglyNumbers[indices[j]] * primes[j];
                }
            }
        }

        return uglyNumbers[n - 1];
    }
}

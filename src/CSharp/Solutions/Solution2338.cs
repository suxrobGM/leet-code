namespace LeetCode.Solutions;

public class Solution2338
{
    /// <summary>
    /// 2338. Count the Number of Ideal Arrays - Hard
    /// <a href="https://leetcode.com/problems/count-the-number-of-ideal-arrays">See the problem</a>
    /// </summary>
    public int IdealArrays(int n, int maxValue)
    {
        const int mod = 1_000_000_007;
        int maxExponent = 0;
        for (int value = maxValue; value > 1; value /= 2)
            maxExponent++;

        var inverses = new long[maxExponent + 1];
        var combinations = new long[maxExponent + 1];
        combinations[0] = 1;

        // combinations[e] = C(n + e - 1, e), using modular inverses.
        for (int exponent = 1; exponent <= maxExponent; exponent++)
        {
            inverses[exponent] = exponent == 1
                ? 1
                : mod - (mod / exponent) * inverses[mod % exponent] % mod;
            combinations[exponent] = combinations[exponent - 1]
                * (n + exponent - 1) % mod * inverses[exponent] % mod;
        }

        var smallestPrime = new int[maxValue + 1];
        for (int prime = 2; prime <= maxValue; prime++)
        {
            if (smallestPrime[prime] != 0) continue;

            for (int multiple = prime; multiple <= maxValue; multiple += prime)
            {
                if (smallestPrime[multiple] == 0)
                    smallestPrime[multiple] = prime;
            }
        }

        long total = 0;
        for (int value = 1; value <= maxValue; value++)
        {
            int remaining = value;
            long count = 1;

            // Divisibility means each prime's exponent can only increase.
            // Distribute its total exponent among the n positions independently.
            while (remaining > 1)
            {
                int prime = smallestPrime[remaining];
                int exponent = 0;
                do
                {
                    remaining /= prime;
                    exponent++;
                }
                while (remaining % prime == 0);

                count = count * combinations[exponent] % mod;
            }

            total = (total + count) % mod;
        }

        return (int)total;
    }
}

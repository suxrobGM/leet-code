namespace LeetCode.Solutions;

public class Solution1994
{
    /// <summary>
    /// 1994. The Number of Good Subsets - Hard
    /// <a href="https://leetcode.com/problems/the-number-of-good-subsets">See the problem</a>
    /// </summary>
    public int NumberOfGoodSubsets(int[] nums)
    {
        int MOD = 1000000007;
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        // Count frequency of each number
        int[] freq = new int[31];
        foreach (int num in nums)
        {
            freq[num]++;
        }

        // Precompute prime masks for each number
        int[] masks = new int[31];
        for (int i = 2; i <= 30; i++)
        {
            masks[i] = GetPrimeMask(i, primes);
        }

        // dp[mask] = number of ways to achieve this prime mask
        long[] dp = new long[1024]; // 2^10 possible masks
        dp[0] = 1; // Empty subset

        // Process each number 2-30
        for (int num = 2; num <= 30; num++)
        {
            if (freq[num] == 0 || masks[num] == -1) continue;

            int mask = masks[num];

            // Update DP backwards to avoid using same state twice
            for (int state = 1023; state >= 0; state--)
            {
                // Can only add if no prime overlap
                if ((state & mask) == 0)
                {
                    int newState = state | mask;
                    // Can use any of the freq[num] copies
                    dp[newState] = (dp[newState] + dp[state] * freq[num]) % MOD;
                }
            }
        }

        // Sum all non-empty subsets
        long result = 0;
        for (int mask = 1; mask < 1024; mask++)
        {
            result = (result + dp[mask]) % MOD;
        }

        // Multiply by 2^(count of 1s) - each subset can include any subset of 1s
        if (freq[1] > 0)
        {
            long power = ModPow(2, freq[1], MOD);
            result = (result * power) % MOD;
        }

        return (int)result;
    }

    private int GetPrimeMask(int num, int[] primes)
    {
        int mask = 0;
        for (int i = 0; i < primes.Length; i++)
        {
            int count = 0;
            while (num % primes[i] == 0)
            {
                count++;
                num /= primes[i];
            }
            if (count > 1) return -1; // Repeated prime factor
            if (count == 1) mask |= (1 << i);
        }
        return mask;
    }

    private long ModPow(long baseNum, int exp, int mod)
    {
        long result = 1;
        while (exp > 0)
        {
            if (exp % 2 == 1) result = (result * baseNum) % mod;
            baseNum = (baseNum * baseNum) % mod;
            exp /= 2;
        }
        return result;
    }
}

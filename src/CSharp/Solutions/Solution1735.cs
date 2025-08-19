using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1735
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1735. Count Ways to Make Array With Product - Hard
    /// <a href="https://leetcode.com/problems/count-ways-to-make-array-with-product">See the problem</a>
    /// </summary>
    public int[] WaysToFillArray(int[][] queries)
    {
        int maxN = 0, maxK = 0;
        foreach (var q in queries)
        {
            if (q[0] > maxN) maxN = q[0];
            if (q[1] > maxK) maxK = q[1];
        }

        // For k <= 1e4, e_max <= 13. Precompute factorials to safe limit.
        int MAX = maxN + 20; // plenty
        long[] fact = new long[MAX + 1];
        long[] invFact = new long[MAX + 1];
        PrecomputeFacts(fact, invFact, MAX);

        // Sieve primes up to maxK for fast factorization
        var primes = Sieve(maxK);

        int[] ans = new int[queries.Length];

        for (int idx = 0; idx < queries.Length; idx++)
        {
            int n = queries[idx][0];
            int k = queries[idx][1];

            long res = 1;
            int x = k;
            foreach (int p in primes)
            {
                if (p * p > x) break;
                if (x % p == 0)
                {
                    int e = 0;
                    while (x % p == 0) { x /= p; e++; }
                    res = (res * nCr(e + n - 1, n - 1, fact, invFact)) % MOD;
                }
            }
            if (x > 1) // leftover prime factor with exponent 1
            {
                res = (res * nCr(1 + n - 1, n - 1, fact, invFact)) % MOD; // == n
            }

            ans[idx] = (int)res;
        }

        return ans;
    }

    // ---------- combinatorics ----------
    private void PrecomputeFacts(long[] fact, long[] invFact, int N)
    {
        fact[0] = 1;
        for (int i = 1; i <= N; i++) fact[i] = (fact[i - 1] * i) % MOD;
        invFact[N] = ModPow(fact[N], MOD - 2);
        for (int i = N - 1; i >= 0; i--) invFact[i] = (invFact[i + 1] * (i + 1)) % MOD;
    }

    private long nCr(int n, int r, long[] fact, long[] invFact)
    {
        if (r < 0 || r > n) return 0;
        return (((fact[n] * invFact[r]) % MOD) * invFact[n - r]) % MOD;
    }

    private long ModPow(long a, long e)
    {
        long res = 1;
        a %= MOD;
        while (e > 0)
        {
            if ((e & 1) == 1) res = (res * a) % MOD;
            a = (a * a) % MOD;
            e >>= 1;
        }
        return res;
    }

    // ---------- sieve ----------
    private List<int> Sieve(int n)
    {
        var primes = new List<int>();
        if (n < 2) return primes;
        bool[] isComp = new bool[n + 1];
        for (int i = 2; i * i <= n; i++)
            if (!isComp[i])
                for (int j = i * i; j <= n; j += i)
                    isComp[j] = true;
        for (int i = 2; i <= n; i++)
            if (!isComp[i]) primes.Add(i);
        return primes;
    }
}

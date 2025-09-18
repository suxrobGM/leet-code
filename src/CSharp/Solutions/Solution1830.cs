using System.Text;

namespace LeetCode.Solutions;

public class Solution1830
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1830. Minimum Number of Operations to Make String Sorted - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-make-string-sorted">See the problem</a>
    /// </summary>
    public int MakeStringSorted(string s)
    {
        int n = s.Length;

        // factorials and inverse factorials up to n
        long[] fact = new long[n + 1];
        long[] invfact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++) fact[i] = fact[i - 1] * i % MOD;
        invfact[n] = ModPow(fact[n], MOD - 2);
        for (int i = n; i >= 1; i--) invfact[i - 1] = invfact[i] * i % MOD;

        // frequency of letters
        int[] cnt = new int[26];
        foreach (char ch in s) cnt[ch - 'a']++;

        long ans = 0;

        for (int i = 0; i < n; i++)
        {
            int cur = s[i] - 'a';
            int rem = n - i - 1;

            // denomInv = Π invfact[cnt[c]]
            long denomInv = 1;
            for (int c = 0; c < 26; c++)
            {
                denomInv = denomInv * invfact[cnt[c]] % MOD;
            }

            // try placing smaller character x at position i
            for (int x = 0; x < cur; x++)
            {
                if (cnt[x] == 0) continue;
                long add = fact[rem] * denomInv % MOD;
                add = add * cnt[x] % MOD; // simplification explained above
                ans = (ans + add) % MOD;
            }

            // fix s[i]: consume one
            cnt[cur]--;
        }

        return (int)ans;
    }

    private long ModPow(long a, long e)
    {
        long res = 1, baseVal = a % MOD;
        while (e > 0)
        {
            if ((e & 1) == 1) res = (res * baseVal) % MOD;
            baseVal = (baseVal * baseVal) % MOD;
            e >>= 1;
        }
        return res;
    }
}

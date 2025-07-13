using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1622
{
    /// <summary>
    /// 1622. Fancy Sequence - Hard
    /// <a href="https://leetcode.com/problems/fancy-sequence">See the problem</a>
    /// </summary>
    public class Fancy
    {
        private const long MOD = 1_000_000_007L;

        // global affine parameters
        private long mul = 1;   // cumulative multiplier
        private long add = 0;   // cumulative adder

        // raw values as defined in the proof
        private readonly List<long> raw = new();

        public Fancy() { }

        // pow(a, MOD-2) because MOD is prime (Fermat)
        private static long ModPow(long a, long e)
        {
            long res = 1;
            while (e > 0)
            {
                if ((e & 1) == 1) res = (res * a) % MOD;
                a = (a * a) % MOD;
                e >>= 1;
            }
            return res;
        }

        public void Append(int val)
        {
            // raw = (val - add) * inv(mul)  (mod MOD)
            long inv = ModPow(mul, MOD - 2);
            long r = (val - add) % MOD;
            if (r < 0) r += MOD;
            r = (r * inv) % MOD;
            raw.Add(r);
        }

        public void AddAll(int inc)
        {
            add = (add + inc) % MOD;
        }

        public void MultAll(int m)
        {
            mul = (mul * m) % MOD;
            add = (add * m) % MOD;
        }

        public int GetIndex(int idx)
        {
            if (idx < 0 || idx >= raw.Count) return -1;
            long value = (raw[idx] * mul + add) % MOD;
            return (int)value;
        }
    }
}

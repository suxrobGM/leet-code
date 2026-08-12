namespace LeetCode.Solutions;

public class Solution2241
{
    /// <summary>
    /// 2241. Design an ATM Machine - Medium
    /// <a href="https://leetcode.com/problems/design-an-atm-machine">See the problem</a>
    /// </summary>
    public class ATM
    {
        private static readonly int[] Denominations = [20, 50, 100, 200, 500];
        private readonly long[] _counts = new long[5];

        public void Deposit(int[] banknotesCount)
        {
            for (var i = 0; i < _counts.Length; i++)
            {
                _counts[i] += banknotesCount[i];
            }
        }

        public int[] Withdraw(int amount)
        {
            var used = new int[_counts.Length];
            var remaining = (long)amount;

            for (var i = _counts.Length - 1; i >= 0 && remaining > 0; i--)
            {
                var take = Math.Min(remaining / Denominations[i], _counts[i]);
                used[i] = (int)take;
                remaining -= take * Denominations[i];
            }

            if (remaining > 0)
            {
                return [-1];
            }

            for (var i = 0; i < _counts.Length; i++)
            {
                _counts[i] -= used[i];
            }

            return used;
        }
    }
}

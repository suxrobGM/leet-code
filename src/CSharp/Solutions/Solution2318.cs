namespace LeetCode.Solutions;

public class Solution2318
{
    /// <summary>
    /// 2318. Number of Distinct Roll Sequences - Hard
    /// <a href="https://leetcode.com/problems/number-of-distinct-roll-sequences">See the problem</a>
    /// </summary>
    public int DistinctSequences(int n)
    {
        const int mod = 1_000_000_007;

        if (n == 1)
        {
            return 6;
        }

        var compatible = new bool[7, 7];
        var dp = new int[7, 7];

        for (var first = 1; first <= 6; first++)
        {
            for (var second = 1; second <= 6; second++)
            {
                compatible[first, second] = first != second && Gcd(first, second) == 1;
                dp[first, second] = compatible[first, second] ? 1 : 0;
            }
        }

        // dp[previous, last] counts sequences ending with these two rolls.
        for (var length = 3; length <= n; length++)
        {
            var next = new int[7, 7];

            for (var previous = 1; previous <= 6; previous++)
            {
                for (var last = 1; last <= 6; last++)
                {
                    for (var roll = 1; roll <= 6; roll++)
                    {
                        if (compatible[last, roll] && roll != previous)
                        {
                            next[last, roll] = (next[last, roll] + dp[previous, last]) % mod;
                        }
                    }
                }
            }

            dp = next;
        }

        var result = 0;
        for (var previous = 1; previous <= 6; previous++)
        {
            for (var last = 1; last <= 6; last++)
            {
                result = (result + dp[previous, last]) % mod;
            }
        }

        return result;

        static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }

            return a;
        }
    }
}

namespace LeetCode.Solutions;

public class Solution2183
{
    /// <summary>
    /// 2183. Count Array Pairs Divisible by K - Hard
    /// <a href="https://leetcode.com/problems/count-array-pairs-divisible-by-k">See the problem</a>
    /// </summary>
    public long CountPairs(int[] nums, int k)
    {
        var counts = new Dictionary<int, long>();
        long result = 0;

        foreach (var num in nums)
        {
            var divisor = Gcd(num, k);

            foreach (var (previousDivisor, count) in counts)
            {
                if ((long)divisor * previousDivisor % k == 0)
                {
                    result += count;
                }
            }

            counts[divisor] = counts.GetValueOrDefault(divisor) + 1;
        }

        return result;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }
}

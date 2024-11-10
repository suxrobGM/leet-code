
namespace LeetCode.Solutions;

public class Solution793
{
    /// <summary>
    /// 793. Preimage Size of Factorial Zeroes Function - Hard
    /// <a href="https://leetcode.com/problems/preimage-size-of-factorial-zeroes-function">See the problem</a>
    /// </summary>
    public int PreimageSizeFZF(int k)
    {
        long left = 0;
        long right = long.MaxValue;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var zeros = TrailingZeroes(mid);

            if (zeros == k)
            {
                return 5;
            }
            else if (zeros < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return 0;
    }

    private long TrailingZeroes(long n)
    {
        long count = 0;
        for (long i = 5; n / i >= 1; i *= 5)
        {
            count += n / i;
        }

        return count;
    }
}

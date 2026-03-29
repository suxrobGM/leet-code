namespace LeetCode.Solutions;

public class Solution2081
{
    /// <summary>
    /// 2081. Sum of k-Mirror Numbers - Hard
    /// <a href="https://leetcode.com/problems/sum-of-k-mirror-numbers">See the problem</a>
    /// </summary>
    public long KMirror(int k, int n)
    {
        long sum = 0;
        var count = 0;

        for (var len = 1; count < n; len++)
        {
            foreach (var num in GeneratePalindromes(len))
            {
                if (IsPalindromeInBase(num, k))
                {
                    sum += num;
                    if (++count == n) break;
                }
            }
        }

        return sum;
    }

    private static IEnumerable<long> GeneratePalindromes(int len)
    {
        var half = (len + 1) / 2;
        var start = (long)Math.Pow(10, half - 1);
        var end = (long)Math.Pow(10, half);
        if (half == 1) start = 1;

        for (var h = start; h < end; h++)
        {
            var s = h.ToString();
            var rev = len % 2 == 1 ? s[..^1] : s;
            var chars = rev.ToCharArray();
            Array.Reverse(chars);
            var palindrome = long.Parse(s + new string(chars));
            yield return palindrome;
        }
    }

    private static bool IsPalindromeInBase(long num, int k)
    {
        Span<int> digits = stackalloc int[64];
        var len = 0;
        var n = num;
        while (n > 0)
        {
            digits[len++] = (int)(n % k);
            n /= k;
        }

        for (int i = 0, j = len - 1; i < j; i++, j--)
        {
            if (digits[i] != digits[j]) return false;
        }

        return true;
    }
}

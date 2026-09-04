namespace LeetCode.Solutions;

public class Solution2269
{
    /// <summary>
    /// 2269. Find the K-Beauty of a Number - Easy
    /// <a href="https://leetcode.com/problems/find-the-k-beauty-of-a-number">See the problem</a>
    /// </summary>
    public int DivisorSubstrings(int num, int k)
    {
        var digits = new List<int>();

        for (var rest = num; rest > 0; rest /= 10)
        {
            digits.Add(rest % 10);
        }

        // digits holds the number in reverse, so the first window covers the leading digits.
        digits.Reverse();

        var divisor = 10;

        for (var i = 1; i < k; i++)
        {
            divisor *= 10;
        }

        var window = 0;
        var beauty = 0;

        for (var i = 0; i < digits.Count; i++)
        {
            window = window * 10 + digits[i];

            if (i >= k)
            {
                // Drop the digit that just left the window.
                window %= divisor;
            }

            if (i >= k - 1 && window != 0 && num % window == 0)
            {
                beauty++;
            }
        }

        return beauty;
    }
}

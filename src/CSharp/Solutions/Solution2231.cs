namespace LeetCode.Solutions;

public class Solution2231
{
    /// <summary>
    /// 2231. Largest Number After Digit Swaps by Parity - Easy
    /// <a href="https://leetcode.com/problems/largest-number-after-digit-swaps-by-parity">See the problem</a>
    /// </summary>
    public int LargestInteger(int num)
    {
        var digits = new List<int>();

        for (int n = num; n > 0; n /= 10)
            digits.Add(n % 10);

        digits.Reverse();

        // A digit only swaps with same-parity digits, so each parity group can be reordered
        // freely: sort both groups descending and refill the positions they already occupy.
        var odds = digits.Where(d => d % 2 != 0).OrderByDescending(d => d).ToArray();
        var evens = digits.Where(d => d % 2 == 0).OrderByDescending(d => d).ToArray();

        int oddIndex = 0, evenIndex = 0, result = 0;

        foreach (var digit in digits)
            result = result * 10 + (digit % 2 != 0 ? odds[oddIndex++] : evens[evenIndex++]);

        return result;
    }
}

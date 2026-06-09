namespace LeetCode.Solutions;

public class Solution2165
{
    /// <summary>
    /// 2165. Smallest Value of the Rearranged Number - Medium
    /// <a href="https://leetcode.com/problems/smallest-value-of-the-rearranged-number">See the problem</a>
    /// </summary>
    public long SmallestNumber(long num)
    {
        if (num == 0) return 0;

        bool negative = num < 0;
        char[] digits = Math.Abs(num).ToString().ToCharArray();

        if (negative)
        {
            // Largest magnitude => digits descending
            Array.Sort(digits, (a, b) => b - a);
            return -long.Parse(new string(digits));
        }

        // Smallest magnitude => digits ascending, no leading zero
        Array.Sort(digits);
        if (digits[0] == '0')
        {
            // Swap first non-zero digit into the front
            int i = 0;
            while (digits[i] == '0') i++;
            (digits[0], digits[i]) = (digits[i], digits[0]);
        }
        return long.Parse(new string(digits));
    }
}

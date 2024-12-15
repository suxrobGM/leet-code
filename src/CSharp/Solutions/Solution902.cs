using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution902
{
    /// <summary>
    /// 902. Numbers At Most N Given Digit Set - Hard
    /// <a href="https://leetcode.com/problems/numbers-at-most-n-given-digit-set">See the problem</a>
    /// </summary>
    public int AtMostNGivenDigitSet(string[] digits, int n)
    {
        var nStr = n.ToString();
        int nLen = nStr.Length;
        int digitsLen = digits.Length;
        int totalCount = 0;

        // Step 1: Count numbers with fewer digits than n
        for (int len = 1; len < nLen; len++)
        {
            totalCount += (int)Math.Pow(digitsLen, len);
        }

        // Step 2: Count numbers with the same number of digits as n
        for (int i = 0; i < nLen; i++)
        {
            var hasSameDigit = false;
            foreach (string digit in digits)
            {
                if (digit[0] < nStr[i])
                {
                    // Count numbers that can be formed with this smaller digit
                    totalCount += (int)Math.Pow(digitsLen, nLen - i - 1);
                }
                else if (digit[0] == nStr[i])
                {
                    hasSameDigit = true;
                }
            }

            // If no digit matches the current digit of n, stop further checks
            if (!hasSameDigit) return totalCount;
        }

        // Include n itself if all digits matched
        return totalCount + 1;
    }
}

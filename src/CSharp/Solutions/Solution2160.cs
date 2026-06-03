namespace LeetCode.Solutions;

public class Solution2160
{
    /// <summary>
    /// 2160. Minimum Sum of Four Digit Number After Splitting Digits - Easy
    /// <a href="https://leetcode.com/problems/minimum-sum-of-four-digit-number-after-splitting-digits">See the problem</a>
    /// </summary>
    public int MinimumSum(int num)
    {
        int[] digits = new int[4];
        for (int i = 0; i < 4; i++)
        {
            digits[i] = num % 10;
            num /= 10;
        }
        Array.Sort(digits);
        return digits[0] * 10 + digits[2] + digits[1] * 10 + digits[3];
    }
}

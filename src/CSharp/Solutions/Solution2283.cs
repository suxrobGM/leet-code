namespace LeetCode.Solutions;

public class Solution2283
{
    private const long Modulo = 1_000_000_007;

    /// <summary>
    /// 2283. Check if Number Has Equal Digit Count and Digit Value - Easy
    /// <a href="https://leetcode.com/problems/check-if-number-has-equal-digit-count-and-digit-value">See the problem</a>
    /// </summary>
    public bool DigitCount(string num)
    {
        var count = new int[10];

        foreach (var digit in num)
        {
            count[digit - '0']++;
        }

        for (var i = 0; i < num.Length; i++)
        {
            if (count[i] != num[i] - '0')
            {
                return false;
            }
        }

        return true;
    }
}

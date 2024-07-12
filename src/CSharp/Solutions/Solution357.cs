namespace LeetCode.Solutions;

public class Solution357
{
    /// <summary>
    /// 357. Count Numbers with Unique Digits - Medium
    /// <a href="https://leetcode.com/problems/count-numbers-with-unique-digits">See the problem</a>
    /// </summary>
    public int CountNumbersWithUniqueDigits(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        var result = 10;
        var uniqueDigits = 9;
        var availableNumbers = 9;

        for (var i = 2; i <= n && availableNumbers > 0; i++)
        {
            uniqueDigits *= availableNumbers;
            result += uniqueDigits;
            availableNumbers--;
        }

        return result;
    }
}

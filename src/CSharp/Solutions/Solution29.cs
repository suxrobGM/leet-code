namespace LeetCode.Solutions;

public class Solution29
{
    /// <summary>
    /// 29. Divide Two Integers
    /// <a href="https://leetcode.com/problems/divide-two-integers">See the problem</a>
    /// </summary>
    public int Divide(int dividend, int divisor)
    {
        var divisorSign = divisor < 0 ? -1 : 1;
        var dividendSign = dividend < 0 ? -1 : 1;
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);
        var quotient = divisor == 1 ? 1 : 0;
        
        if (dividend == 0 || divisor > dividend)
        {
            return 0;
        }

        while (dividend > 1)
        {
            dividend -= divisor;
            quotient++;
        }
        
        return quotient * dividendSign * divisorSign;
    }
}

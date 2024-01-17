namespace LeetCode.Solutions;

public class Solution29
{
    /// <summary>
    /// 29. Divide Two Integers
    /// <a href="https://leetcode.com/problems/divide-two-integers">See the problem</a>
    /// </summary>
    public int Divide(int dividend, int divisor)
    {
        // Handle overflow case
        if (dividend == int.MinValue && divisor == -1) 
        {
            return int.MaxValue;
        }

        // Convert both numbers to long to avoid overflow issues
        var dividendLong = Math.Abs((long)dividend);
        var divisorLong = Math.Abs((long)divisor);

        // Determine the sign of the result
        var sign = (dividend < 0) ^ (divisor < 0) ? -1 : 1;
        long quotient = 0;
        
        while (dividendLong >= divisorLong)
        {
            var value = divisorLong;
            var multiple = 1L;
            
            while (dividendLong >= value << 1) 
            {
                value <<= 1;
                multiple <<= 1;
            }
            
            dividendLong -= value;
            quotient += multiple;
        }

        // Apply the sign and handle overflow if any
        var result = sign * quotient;
        
        return result switch
        {
            > int.MaxValue => int.MaxValue,
            < int.MinValue => int.MinValue,
            _ => (int)result
        };
    }
}

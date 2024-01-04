namespace LeetCode.Solutions;

public class Solution8
{
    /// <summary>
    /// Problem #8
    /// <a href="https://leetcode.com/problems/string-to-integer-atoi/">See the problem</a>
    /// </summary>
    public int MyAtoi(string s)
    {
        var trimmedStr = s.Trim();
        var result = 0;
        var sign = 1; // default sign is positive
        var index = 0;

        try
        {
            checked
            {
                // Check for sign
                if (index < trimmedStr.Length && IsSignOp(trimmedStr[index]))
                {
                    sign = trimmedStr[index] == '-' ? -1 : 1;
                    index++; // move to the next character
                }

                // Process digits
                while (index < trimmedStr.Length && char.IsDigit(trimmedStr[index]))
                {
                    result = result * 10 + ToInt(trimmedStr[index]); // append the digit
                    index++;
                }
            }
        }
        catch (OverflowException)
        {
            // clamp result if it exceeds the int32 range
            return sign == -1 ? int.MinValue : int.MaxValue;
        }
        
        return sign * result;
    }

    private bool IsSignOp(char c)
    {
        return c is '-' or '+';
    }
    
    private int ToInt(char c)
    {
        return c - '0';
    }
}

namespace LeetCode.Solutions;

public class Solution65
{
    /// <summary>
    /// 65. Valid Number - Hard
    /// <a href="https://leetcode.com/problems/valid-number">See the problem</a>
    /// </summary>
    public bool IsNumber(string s)
    {
        var i = 0;
        var n = s.Length;
        var isNumeric = false;

        // Trim leading and trailing spaces
        s = s.Trim();

        // Check for optional sign
        if (i < n && (s[i] == '+' || s[i] == '-'))
        {
            i++;
        }

        // Check for digits before the dot
        while (i < n && char.IsDigit(s[i]))
        {
            i++;
            isNumeric = true;
        }

        // Check if there is a dot and digits after
        if (i < n && s[i] == '.')
        {
            i++; // Skip the dot
            // It's still valid if there are digits after the dot
            while (i < n && char.IsDigit(s[i]))
            {
                i++;
                isNumeric = true;
            }
        }

        // Check for exponent part
        if (isNumeric && i < n && (s[i] == 'e' || s[i] == 'E'))
        {
            i++; // Skip 'e' or 'E'
            isNumeric = false; // Reset for exponent validation
            
            // Optional sign in exponent
            if (i < n && (s[i] == '+' || s[i] == '-'))
            {
                i++;
            } 
            
            // Check digits in exponent
            while (i < n && char.IsDigit(s[i]))
            {
                i++;
                isNumeric = true;
            }
        }

        // Ensure the whole string is processed and a number is present
        return isNumeric && i == n;
    }
}

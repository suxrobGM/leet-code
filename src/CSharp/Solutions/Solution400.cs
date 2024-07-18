namespace LeetCode.Solutions;

public class Solution400
{
    /// <summary>
    /// 400. Nth Digit - Easy
    /// <a href="https://leetcode.com/problems/nth-digit">See the problem</a>
    /// </summary>
    public int FindNthDigit(int n)
    {
        long digitLength = 1; // the number of digits in the current range
        long count = 9;       // the count of numbers in the current range
        long start = 1;       // the starting number of the current range

        while (n > digitLength * count) 
        {
            n -= (int)(digitLength * count);
            digitLength++;
            count *= 10;
            start *= 10;
        }

        // Step 2: Find the exact number
        start += (n - 1) / digitLength;
        string s = start.ToString();
        
        // Step 3: Find the exact digit
        return s[(n - 1) % (int)digitLength] - '0';
    }
}

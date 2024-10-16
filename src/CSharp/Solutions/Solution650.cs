namespace LeetCode.Solutions;

public class Solution650
{
    /// <summary>
    /// 650. 2 Keys Keyboard - Medium
    /// <a href="https://leetcode.com/problems/2-keys-keyboard">See the problem</a>
    /// </summary>
    public int MinSteps(int n)
    {
        var result = 0;
        var factor = 2;

        // While n is greater than 1, break it down by its factors
        while (n > 1)
        {
            while (n % factor == 0)
            {
                result += factor;  // Add the factor to the result (indicates number of operations)
                n /= factor;  // Divide n by the factor
            }
            factor++;
        }

        return result;
    }
}

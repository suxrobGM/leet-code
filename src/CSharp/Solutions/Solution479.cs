namespace LeetCode.Solutions;

public class Solution479
{
    /// <summary>
    /// 479. Largest Palindrome Product - Easy
    /// <a href="https://leetcode.com/problems/largest-palindrome-product">See the problem</a>
    /// </summary>
    public int LargestPalindrome(int n)
    {
        if (n == 1)
        { 
            return 9; // Special case for n = 1
        }  

        var upperLimit = (int)Math.Pow(10, n) - 1; // Largest n-digit number
        var lowerLimit = (int)Math.Pow(10, n - 1); // Smallest n-digit number
        long maxPalindrome = 0;

        for (int i = upperLimit; i >= lowerLimit; i--)
        {
            for (int j = i; j >= lowerLimit; j--)
            {
                long product = (long)i * j;

                if (product <= maxPalindrome) 
                {
                    break; // No need to check further if product is smaller
                }  

                if (IsPalindrome(product))
                {
                    maxPalindrome = product;
                    break;  // Break inner loop as we don't need smaller j
                }
            }
        }

        return (int)(maxPalindrome % 1337);
    }

    private bool IsPalindrome(long num)
    {
        long original = num;
        long reversed = 0;

        while (num > 0)
        {
            reversed = reversed * 10 + num % 10;
            num /= 10;
        }

        return original == reversed;
    }
}

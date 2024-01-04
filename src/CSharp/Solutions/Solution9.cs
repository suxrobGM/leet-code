namespace LeetCode.Solutions;

public class Solution9
{
    /// <summary>
    /// Given an integer x, return true if x is palindrome integer.
    /// An integer is a palindrome when it reads the same backward as forward.
    /// For example, 121 is a palindrome while 123 is not.
    /// <see href="https://leetcode.com/problems/palindrome-number/">See the problem</see>
    /// </summary>
    /// <remarks>Time complexity O(n)</remarks>
    public bool IsPalindrome(int x)
    {
        if (x < 0) 
            return false;

        var str = x.ToString();
        var len = str.Length;
        var isPalindrome = true;

        if (len == 1)
        {
            return isPalindrome;
        }

        for (var i = 0; i < len / 2; i++)
        {
            if (str[i] != str[len - i - 1])
            {
                isPalindrome = false;
                break;
            }
        }

        return isPalindrome;
    }
}

namespace LeetCode.Solutions;

public class Solution5
{
    /// <summary>
    /// Given a string s, return the longest palindromic substring in s.
    /// <a href="https://leetcode.com/problems/longest-palindromic-substring/">See the problem</a>
    /// </summary>
    /// <remarks>Best case O(n), worst case O(n^3)</remarks>
    public string LongestPalindrome(string s)
    {
        var len = s.Length;

        if (len == 1)
        {
            return s;
        }

        // Check string is palindrome itself
        if (IsPalindrome(s))
        {
            return s;
        }

        // Total possible substrings for string of size n is n*(n+1)/2  
        var res = "";
        var maxLen = 0;

        for (var i = 0; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                var substr = s.Substring(i, j + 1);      

                if (IsPalindrome(substr))
                {
                    if (substr.Length > maxLen)
                    {
                        res = substr;
                        maxLen = substr.Length;
                    }
                }
            }
        }

        return res;
    }

    private bool IsPalindrome(string str)
    {
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

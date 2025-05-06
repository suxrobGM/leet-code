using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1328
{
    /// <summary>
    /// 1328. Break a Palindrome - Medium
    /// <a href="https://leetcode.com/problems/break-a-palindrome">See the problem</a>
    /// </summary>
    public string BreakPalindrome(string palindrome)
    {
        int n = palindrome.Length;
        if (n == 1) return ""; // A single character cannot be broken into a non-palindrome.

        char[] chars = palindrome.ToCharArray();
        for (int i = 0; i < n / 2; i++)
        {
            if (chars[i] != 'a')
            {
                chars[i] = 'a'; // Change the first non-'a' character to 'a'.
                return new string(chars);
            }
        }

        // If all characters are 'a', change the last character to 'b'.
        chars[n - 1] = 'b';
        return new string(chars);
    }
}

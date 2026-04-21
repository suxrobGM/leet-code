using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2108
{
    /// <summary>
    /// 2108. Find First Palindromic String in the Array - Easy
    /// <a href="https://leetcode.com/problems/find-first-palindromic-string-in-the-array">See the problem</a>
    /// </summary>
    public string FirstPalindrome(string[] words)
    {
        foreach (var word in words)
        {
            if (IsPalindrome(word))
            {
                return word;
            }
        }

        return string.Empty;
    }

    private static bool IsPalindrome(string word)
    {
        var i = 0;
        var j = word.Length - 1;

        while (i < j)
        {
            if (word[i] != word[j])
            {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }
}

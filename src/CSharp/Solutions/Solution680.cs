using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution680
{
    /// <summary>
    /// 680. Valid Palindrome II - Easy
    /// <a href="https://leetcode.com/problems/valid-palindrome-ii">See the problem</a>
    /// </summary>
    public bool ValidPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
            {
                return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
            }
            left++;
            right--;
        }

        return true;
    }

    private static bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}

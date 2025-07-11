using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1616
{
    /// <summary>
    /// 1616. Split Two Strings to Make Palindrome - Medium
    /// <a href="https://leetcode.com/problems/split-two-strings-to-make-palindrome">See the problem</a>
    /// </summary>
    public bool CheckPalindromeFormation(string a, string b)
    {
        return Check(a, b) || Check(b, a);
    }

    private bool Check(string a, string b)
    {
        int left = 0, right = a.Length - 1;

        while (left < right && a[left] == b[right])
        {
            left++;
            right--;
        }

        // Now either a[left...right] or b[left...right] must be a palindrome
        return IsPalindrome(a, left, right) || IsPalindrome(b, left, right);
    }

    private bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right]) return false;
            left++;
            right--;
        }
        return true;
    }
}

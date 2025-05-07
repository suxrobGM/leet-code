using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1332
{
    /// <summary>
    /// 1332. Remove Palindromic Subsequences - Easy
    /// <a href="https://leetcode.com/problems/remove-palindromic-subsequences">See the problem</a>
    /// </summary>
    public int RemovePalindromeSub(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        int n = s.Length;
        for (int i = 0; i < n / 2; i++)
        {
            if (s[i] != s[n - 1 - i])
                return 2; // Not a palindrome, need to remove both 'a' and 'b' subsequences
        }
        return 1; // It's a palindrome, can remove it in one step
    }
}

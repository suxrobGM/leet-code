using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1930
{
    /// <summary>
    /// 1930. Unique Length-3 Palindromic Subsequences - Medium
    /// <a href="https://leetcode.com/problems/unique-length-3-palindromic-subsequences">See the problem</a>
    /// </summary>
    public int CountPalindromicSubsequence(string s)
    {
        int count = 0;

        // For each possible outer character
        for (char c = 'a'; c <= 'z'; c++)
        {
            int first = -1, last = -1;

            // Find first and last occurrence of character c
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    if (first == -1) first = i;
                    last = i;
                }
            }

            // If character appears at least twice
            if (first != -1 && first != last)
            {
                // Find all unique characters between first and last occurrence
                var middleChars = new HashSet<char>();
                for (int i = first + 1; i < last; i++)
                {
                    middleChars.Add(s[i]);
                }

                // Each unique middle character forms a distinct palindrome cXc
                count += middleChars.Count;
            }
        }

        return count;
    }
}

namespace LeetCode.Solutions;

public class Solution647
{
    /// <summary>
    /// 647. Palindromic Substrings - Medium
    /// <a href="https://leetcode.com/problems/palindromic-substrings">See the problem</a>
    /// </summary>
    public int CountSubstrings(string s)
    {
        var n = s.Length;
        var count = 0;

        // Function to expand around the center and count palindromes
        void ExpandAroundCenter(int left, int right)
        {
            while (left >= 0 && right < n && s[left] == s[right])
            {
                count++; // Found a palindrome
                left--;
                right++;
            }
        }

        // Expand around every center
        for (var i = 0; i < n; i++)
        {
            // Odd-length palindromes (single character center)
            ExpandAroundCenter(i, i);
            // Even-length palindromes (two character center)
            ExpandAroundCenter(i, i + 1);
        }

        return count;
    }
}

namespace LeetCode.Solutions;

public class Solution10
{
    /// <summary>
    /// Problem #10
    /// <a href="https://leetcode.com/problems/regular-expression-matching/">See the problem</a>
    /// </summary>
    public bool IsMatch(string s, string p)
    {
        // Base case: if the pattern is empty, return true if the string is also empty
        if (string.IsNullOrEmpty(p))
        {
            return string.IsNullOrEmpty(s);
        }

        // First character match flag (considering '.' wildcard)
        var firstMatch = !string.IsNullOrEmpty(s) && (s[0] == p[0] || p[0] == '.');

        // If the pattern has a '*' character
        if (p.Length >= 2 && p[1] == '*') {
            // Two possibilities:
            // 1. '*' acts as zero occurrence
            // 2. '*' acts as one or more occurrence (first character must match)
            return IsMatch(s, p[2..]) || 
                   (firstMatch && IsMatch(s[1..], p));
        }

        // If no '*', just move to the next character in both string and pattern
        return firstMatch && IsMatch(s[1..], p[1..]);
    }
}

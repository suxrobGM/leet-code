using System.Text;

namespace LeetCode.Solutions;

public class Solution1081
{
    /// <summary>
    /// 1081. Smallest Subsequence of Distinct Characters - Medium
    /// <a href="https://leetcode.com/problems/smallest-subsequence-of-distinct-characters">See the problem</a>
    /// </summary>
    public string RemoveDuplicateLetters(string s)
    {
        var charCount = new int[26]; // Frequency of each character
        var inStack = new bool[26]; // Track characters in the stack
        var stack = new Stack<char>();

        // Count the frequency of each character
        foreach (var c in s)
        {
            charCount[c - 'a']++;
        }

        foreach (var c in s)
        {
            // Decrement the count for the current character
            charCount[c - 'a']--;

            // If character is already in the stack, skip
            if (inStack[c - 'a'])
            {
                continue;
            }

            // Ensure characters are in lexicographical order and each character appears once
            while (stack.Count > 0 && stack.Peek() > c && charCount[stack.Peek() - 'a'] > 0)
            {
                inStack[stack.Pop() - 'a'] = false;
            }

            // Add the current character to the stack and mark it as added
            stack.Push(c);
            inStack[c - 'a'] = true;
        }

        // Build the result string from the stack
        var result = new StringBuilder();
        foreach (var c in stack.Reverse())
        {
            result.Append(c);
        }

        return result.ToString();
    }
}

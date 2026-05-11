using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2131
{
    /// <summary>
    /// 2131. Longest Palindrome by Concatenating Two Letter Words - Medium
    /// <a href="https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words">See the problem</a>
    /// </summary>
    public int LongestPalindrome(string[] words)
    {
        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!wordCount.ContainsKey(word))
                wordCount[word] = 0;
            wordCount[word]++;
        }

        var longestLength = 0;
        var hasCentralWord = false;

        foreach (var kvp in wordCount)
        {
            var word = kvp.Key;
            var count = kvp.Value;
            var reversedWord = new string(word.Reverse().ToArray());

            if (word == reversedWord)
            {
                longestLength += (count / 2) * 4;
                if (count % 2 == 1)
                    hasCentralWord = true;
            }
            else if (wordCount.ContainsKey(reversedWord))
            {
                longestLength += Math.Min(count, wordCount[reversedWord]) * 4;
                wordCount[reversedWord] = 0; // Avoid double counting
            }
        }

        if (hasCentralWord)
            longestLength += 2;

        return longestLength;
    }
}

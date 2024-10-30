using System.Text;

namespace LeetCode.Solutions;

public class Solution720
{
    /// <summary>
    /// 720. Longest Word in Dictionary - Medium
    /// <a href="https://leetcode.com/problems/longest-word-in-dictionary">See the problem</a>
    /// </summary>
    public string LongestWord(string[] words)
    {
        Array.Sort(words); // Sort words lexicographically

        var builtWords = new HashSet<string>
        {
            "" // Start with an empty string as base
        };

        var longestWord = "";

        foreach (var word in words)
        {
            // Check if the prefix exists in builtWords
            if (builtWords.Contains(word.Substring(0, word.Length - 1)))
            {
                builtWords.Add(word); // Add the word as it can be built
                // Update longestWord if this word is longer or lexicographically smaller
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
        }

        return longestWord;
    }
}

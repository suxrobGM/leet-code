using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution820
{
    /// <summary>
    /// 820. Short Encoding of Words - Medium
    /// <a href="https://leetcode.com/problems/short-encoding-of-words">See the problem</a>
    /// </summary>
    public int MinimumLengthEncoding(string[] words)
    {
        // Add all words to a HashSet
        var wordSet = new HashSet<string>(words);

        // Remove any word that is a suffix of another word
        foreach (var word in words)
        {
            for (var i = 1; i < word.Length; i++)
            {
                wordSet.Remove(word.Substring(i));
            }
        }

        // Compute the total encoding length
        var totalLength = 0;
        foreach (var word in wordSet)
        {
            totalLength += word.Length + 1; // Include '#' in the length
        }

        return totalLength;
    }
}

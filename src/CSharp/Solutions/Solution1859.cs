using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1859
{
    /// <summary>
    /// 1859. Sorting the Sentence - Easy
    /// <a href="https://leetcode.com/problems/sorting-the-sentence">See the problem</a>
    /// </summary>
    public string SortSentence(string s)
    {
        var words = s.Split(' ');
        var sortedWords = new string[words.Length];

        foreach (var word in words)
        {
            int index = word[^1] - '1'; // Get the index from the last character
            sortedWords[index] = word[..^1]; // Remove the last character and store the word
        }

        return string.Join(' ', sortedWords);
    }
}

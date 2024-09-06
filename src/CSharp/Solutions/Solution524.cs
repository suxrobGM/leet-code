using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution524
{
    /// <summary>
    /// 524. Longest Word in Dictionary through Deleting - Medium
    /// <a href="https://leetcode.com/problems/longest-word-in-dictionary-through-deleting">See the problem</a>
    /// </summary>
    public string FindLongestWord(string s, IList<string> dictionary)
    {
        var longestWord = string.Empty;

        foreach (var word in dictionary)
        {
            if (IsSubsequence(s, word))
            {
                if (word.Length > longestWord.Length || word.Length == longestWord.Length && string.Compare(word, longestWord) < 0)
                {
                    longestWord = word;
                }
            }
        }

        return longestWord;
    }

    private bool IsSubsequence(string s, string word)
    {
        int i = 0;
        int j = 0;

        while (i < s.Length && j < word.Length)
        {
            if (s[i] == word[j])
            {
                j++;
            }

            i++;
        }

        return j == word.Length;
    }
}

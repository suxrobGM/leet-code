using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution890
{
    /// <summary>
    /// 890. Find and Replace Pattern - Medium
    /// <a href="https://leetcode.com/problems/find-and-replace-pattern">See the problem</a>
    /// </summary>
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        var result = new List<string>();

        foreach (var word in words)
        {
            if (IsMatch(word, pattern))
            {
                result.Add(word);
            }
        }

        return result;
    }

    private bool IsMatch(string word, string pattern)
    {
        var wordToPattern = new Dictionary<char, char>();
        var patternToWord = new Dictionary<char, char>();

        for (var i = 0; i < word.Length; i++)
        {
            var wordChar = word[i];
            var patternChar = pattern[i];

            if (!wordToPattern.ContainsKey(wordChar))
            {
                wordToPattern[wordChar] = patternChar;
            }

            if (!patternToWord.ContainsKey(patternChar))
            {
                patternToWord[patternChar] = wordChar;
            }

            if (wordToPattern[wordChar] != patternChar || patternToWord[patternChar] != wordChar)
            {
                return false;
            }
        }

        return true;
    }
}

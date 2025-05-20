using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1455
{
    /// <summary>
    /// 1455. Check If a Word Occurs As a Prefix of Any Word in a Sentence - Easy
    /// <a href="https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence">See the problem</a>
    /// </summary>
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        // Split the sentence into words
        var words = sentence.Split(' ');

        // Iterate through each word
        for (int i = 0; i < words.Length; i++)
        {
            // Check if the current word starts with the searchWord
            if (words[i].StartsWith(searchWord))
            {
                return i + 1; // Return the 1-based index
            }
        }

        return -1; // Return -1 if no word starts with searchWord
    }
}

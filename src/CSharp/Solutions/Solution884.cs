using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution884
{
    /// <summary>
    /// 884. Uncommon Words from Two Sentences - Easy
    /// <a href="https://leetcode.com/problems/uncommon-words-from-two-sentences">See the problem</a>
    /// </summary>
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var words = new Dictionary<string, int>();

        foreach (var word in s1.Split(' '))
        {
            if (!words.ContainsKey(word))
            {
                words[word] = 0;
            }

            words[word]++;
        }

        foreach (var word in s2.Split(' '))
        {
            if (!words.ContainsKey(word))
            {
                words[word] = 0;
            }
                
            words[word]++;
        }

        var uncommonWords = new List<string>();

        foreach (var (word, count) in words)
        {
            if (count == 1) uncommonWords.Add(word);
        }

        return [.. uncommonWords];
    }
}

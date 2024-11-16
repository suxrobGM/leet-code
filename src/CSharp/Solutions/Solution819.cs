using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution819
{
    /// <summary>
    /// 819. Most Common Word - Easy
    /// <a href="https://leetcode.com/problems/most-common-word">See the problem</a>
    /// </summary>
    public string MostCommonWord(string paragraph, string[] banned)
    {
        var bannedSet = new HashSet<string>(banned);
        var wordCount = new Dictionary<string, int>();
        var maxCount = 0;
        var mostCommonWord = string.Empty;

        var word = new StringBuilder();
        foreach (var c in paragraph)
        {
            if (char.IsLetter(c))
            {
                word.Append(char.ToLower(c));
            }
            else if (word.Length > 0)
            {
                var w = word.ToString();
                if (!bannedSet.Contains(w))
                {
                    wordCount[w] = wordCount.GetValueOrDefault(w, 0) + 1;
                    if (wordCount[w] > maxCount)
                    {
                        maxCount = wordCount[w];
                        mostCommonWord = w;
                    }
                }

                word.Clear();
            }
        }

        if (word.Length > 0)
        {
            var w = word.ToString();
            if (!bannedSet.Contains(w))
            {
                wordCount[w] = wordCount.GetValueOrDefault(w, 0) + 1;
                if (wordCount[w] > maxCount)
                {
                    mostCommonWord = w;
                }
            }
        }

        return mostCommonWord;
    }
}

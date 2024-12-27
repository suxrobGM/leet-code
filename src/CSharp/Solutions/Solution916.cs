using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution916
{
    /// <summary>
    /// 916. Word Subsets - Medium
    /// <a href="https://leetcode.com/problems/word-subsets">See the problem</a>
    /// </summary>
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        var result = new List<string>();
        var maxCount = new int[26];
        foreach (var word in words2)
        {
            var count = GetCharCount(word);
            for (var i = 0; i < 26; i++)
            {
                maxCount[i] = Math.Max(maxCount[i], count[i]);
            }
        }

        foreach (var word in words1)
        {
            var count = GetCharCount(word);
            var isUniversal = true;
            for (var i = 0; i < 26; i++)
            {
                if (count[i] < maxCount[i])
                {
                    isUniversal = false;
                    break;
                }
            }

            if (isUniversal)
            {
                result.Add(word);
            }
        }

        return result;
    }

    private int[] GetCharCount(string word)
    {
        var count = new int[26];
        foreach (var ch in word)
        {
            count[ch - 'a']++;
        }

        return count;
    }
}

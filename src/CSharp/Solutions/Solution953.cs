using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution953
{
    /// <summary>
    /// 953. Verifying an Alien Dictionary - Easy
    /// <a href="https://leetcode.com/problems/verifying-an-alien-dictionary">See the problem</a>
    /// </summary>
    public bool IsAlienSorted(string[] words, string order)
    {
        var orderMap = new int[26];

        for (var i = 0; i < order.Length; i++)
        {
            orderMap[order[i] - 'a'] = i;
        }

        for (var i = 1; i < words.Length; i++)
        {
            if (!IsSorted(words[i - 1], words[i], orderMap))
            {
                return false;
            }
        }

        return true;
    }

    private bool IsSorted(string word1, string word2, int[] orderMap)
    {
        var i = 0;

        while (i < word1.Length && i < word2.Length)
        {
            if (word1[i] != word2[i])
            {
                return orderMap[word1[i] - 'a'] < orderMap[word2[i] - 'a'];
            }

            i++;
        }

        return word1.Length <= word2.Length;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1160
{
    /// <summary>
    /// 1160. Find Words That Can Be Formed by Characters - Easy
    /// <a href="https://leetcode.com/problems/find-words-that-can-be-formed-by-characters">See the problem</a>
    /// </summary>
    public int CountCharacters(string[] words, string chars)
    {
        var freq = new int[26];
        foreach (var ch in chars)
        {
            freq[ch - 'a']++;
        }

        var result = 0;
        foreach (var word in words)
        {
            var tempFreq = new int[26];
            foreach (var ch in word)
            {
                tempFreq[ch - 'a']++;
            }

            var isGood = true;
            for (var i = 0; i < 26; i++)
            {
                if (tempFreq[i] > freq[i])
                {
                    isGood = false;
                    break;
                }
            }

            if (isGood)
            {
                result += word.Length;
            }
        }

        return result;
    }
}

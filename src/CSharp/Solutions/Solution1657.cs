using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1657
{
    /// <summary>
    /// 1657. Determine if Two Strings Are Close - Medium
    /// <a href="https://leetcode.com/problems/determine-if-two-strings-are-close">See the problem</a>
    /// </summary>
    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length)
            return false;

        var freq1 = new int[26];
        var freq2 = new int[26];

        foreach (char c in word1)
            freq1[c - 'a']++;

        foreach (char c in word2)
            freq2[c - 'a']++;

        // Check if both strings use the same characters
        for (int i = 0; i < 26; i++)
        {
            if ((freq1[i] == 0 && freq2[i] > 0) || (freq2[i] == 0 && freq1[i] > 0))
                return false;
        }

        // Compare frequency counts (after sorting)
        Array.Sort(freq1);
        Array.Sort(freq2);

        for (int i = 0; i < 26; i++)
        {
            if (freq1[i] != freq2[i])
                return false;
        }

        return true;
    }
}

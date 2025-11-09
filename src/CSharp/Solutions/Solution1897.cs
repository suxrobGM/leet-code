using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1897
{
    /// <summary>
    /// 1897. Redistribute Characters to Make All Strings Equal - Easy
    /// <a href="https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal">See the problem</a>
    /// </summary>
    public bool MakeEqual(string[] words)
    {
        int n = words.Length;
        int[] charCounts = new int[26];

        // Count total occurrences of each character across all words
        foreach (var word in words)
        {
            foreach (var ch in word)
            {
                charCounts[ch - 'a']++;
            }
        }

        // Check if each character's total count is divisible by the number of words
        foreach (var count in charCounts)
        {
            if (count % n != 0)
                return false;
        }

        return true;
    }
}

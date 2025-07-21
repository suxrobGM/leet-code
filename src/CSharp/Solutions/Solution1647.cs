using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1647
{
    /// <summary>
    /// 1647. Minimum Deletions to Make Character Frequencies Unique - Medium
    /// <a href="https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique">See the problem</a>
    /// </summary>
    public int MinDeletions(string s)
    {
        int[] freq = new int[26];
        foreach (char c in s)
        {
            freq[c - 'a']++;
        }

        var seen = new HashSet<int>();
        int deletions = 0;

        for (int i = 0; i < freq.Length; i++)
        {
            while (freq[i] > 0 && !seen.Add(freq[i]))
            {
                freq[i]--;
                deletions++;
            }
        }

        return deletions;
    }
}

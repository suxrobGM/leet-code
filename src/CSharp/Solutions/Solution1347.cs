using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1347
{
    /// <summary>
    /// 1347. Minimum Number of Steps to Make Two Strings Anagram - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram">See the problem</a>
    /// </summary>
    public int MinSteps(string s, string t)
    {
        var sCount = new int[26];
        var tCount = new int[26];

        foreach (char c in s)
        {
            sCount[c - 'a']++;
        }

        foreach (char c in t)
        {
            tCount[c - 'a']++;
        }

        int steps = 0;
        for (int i = 0; i < 26; i++)
        {
            steps += Math.Abs(sCount[i] - tCount[i]);
        }

        return steps / 2;
    }
}

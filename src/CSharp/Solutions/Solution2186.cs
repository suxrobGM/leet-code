namespace LeetCode.Solutions;

public class Solution2186
{
    /// <summary>
    /// 2186. Minimum Number of Steps to Make Two Strings Anagram II - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram-ii">See the problem</a>
    /// </summary>
    public int MinSteps(string s, string t)
    {
        var count = 0;
        var sCount = new int[26];
        var tCount = new int[26];

        foreach (var c in s)
        {
            sCount[c - 'a']++;
        }

        foreach (var c in t)
        {
            tCount[c - 'a']++;
        }

        for (var i = 0; i < 26; i++)
        {
            count += Math.Abs(sCount[i] - tCount[i]);
        }

        return count;
    }
}

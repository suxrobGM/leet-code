namespace LeetCode.Solutions;

public class Solution2068
{
    /// <summary>
    /// 2068. Check Whether Two Strings are Almost Equivalent - Easy
    /// <a href="https://leetcode.com/problems/check-whether-two-strings-are-almost-equivalent">See the problem</a>
    /// </summary>
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        var count1 = new int[26];
        var count2 = new int[26];

        foreach (var c in word1)
            count1[c - 'a']++;

        foreach (var c in word2)
            count2[c - 'a']++;

        for (var i = 0; i < 26; i++)
            if (Math.Abs(count1[i] - count2[i]) > 3)
                return false;

        return true;
    }
}

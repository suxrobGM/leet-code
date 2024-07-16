namespace LeetCode.Solutions;

public class Solution389
{
    /// <summary>
    /// 389. Find the Difference - Easy
    /// <a href="https://leetcode.com/problems/find-the-difference">See the problem</a>
    /// </summary>
    public char FindTheDifference(string s, string t)
    {
        var charCount = new int[26];

        foreach (var c in s)
        {
            charCount[c - 'a']++;
        }

        foreach (var c in t)
        {
            if (charCount[c - 'a'] == 0)
            {
                return c;
            }

            charCount[c - 'a']--;
        }

        return default;
    }
}

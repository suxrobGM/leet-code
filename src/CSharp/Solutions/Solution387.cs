namespace LeetCode.Solutions;

public class Solution387
{
    /// <summary>
    /// 387. First Unique Character in a String - Easy
    /// <a href="https://leetcode.com/problems/first-unique-character-in-a-string">See the problem</a>
    /// </summary>
    public int FirstUniqChar(string s)
    {
        var charCount = new int[26];

        foreach (var c in s)
        {
            charCount[c - 'a']++;
        }

        for (var i = 0; i < s.Length; i++)
        {
            if (charCount[s[i] - 'a'] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}

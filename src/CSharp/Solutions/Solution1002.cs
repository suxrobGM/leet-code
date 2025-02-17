using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1002
{
    /// <summary>
    /// 1002. Find Common Characters - Easy
    /// <a href="https://leetcode.com/problems/find-common-characters</a>
    /// </summary>
    public IList<string> CommonChars(string[] words)
    {
        int[] common = new int[26];
        Array.Fill(common, int.MaxValue);

        foreach (var word in words)
        {
            int[] count = new int[26];
            foreach (var c in word)
            {
                count[c - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                common[i] = Math.Min(common[i], count[i]);
            }
        }

        List<string> result = new();
        for (char c = 'a'; c <= 'z'; c++)
        {
            int count = common[c - 'a'];
            for (int i = 0; i < count; i++)
            {
                result.Add(c.ToString());
            }
        }

        return result;
    }
}

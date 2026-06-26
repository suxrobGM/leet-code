namespace LeetCode.Solutions;

public class Solution2185
{
    /// <summary>
    /// 2185. Counting Words With a Given Prefix - Easy
    /// <a href="https://leetcode.com/problems/counting-words-with-a-given-prefix">See the problem</a>
    /// </summary>
    public int PrefixCount(string[] words, string pref)
    {
        var count = 0;

        foreach (var word in words)
        {
            if (word.StartsWith(pref))
            {
                count++;
            }
        }

        return count;
    }
}

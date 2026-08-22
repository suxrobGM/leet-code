namespace LeetCode.Solutions;

public class Solution2255
{
    /// <summary>
    /// 2255. Count Prefixes of a Given String - Easy
    /// <a href="https://leetcode.com/problems/count-prefixes-of-a-given-string">See the problem</a>
    /// </summary>
    public int CountPrefixes(string[] words, string s)
    {
        var count = 0;

        foreach (var word in words)
        {
            if (s.StartsWith(word))
            {
                count++;
            }
        }

        return count;
    }
}

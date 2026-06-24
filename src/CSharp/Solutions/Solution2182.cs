using System.Text;

namespace LeetCode.Solutions;

public class Solution2182
{
    /// <summary>
    /// 2182. Construct String With Repeat Limit - Medium
    /// <a href="https://leetcode.com/problems/construct-string-with-repeat-limit">See the problem</a>
    /// </summary>
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        var counts = new int[26];
        foreach (var c in s)
        {
            counts[c - 'a']++;
        }

        var result = new StringBuilder(s.Length);
        var current = 25;

        while (current >= 0)
        {
            if (counts[current] == 0)
            {
                current--;
                continue;
            }

            var use = Math.Min(counts[current], repeatLimit);
            result.Append((char)('a' + current), use);
            counts[current] -= use;

            if (counts[current] == 0)
            {
                continue;
            }

            var next = current - 1;
            while (next >= 0 && counts[next] == 0)
            {
                next--;
            }

            if (next < 0)
            {
                break;
            }

            result.Append((char)('a' + next));
            counts[next]--;
        }

        return result.ToString();
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution791
{
    /// <summary>
    /// 791. Custom Sort String - Medium
    /// <a href="https://leetcode.com/problems/custom-sort-string">See the problem</a>
    /// </summary>
    public string CustomSortString(string order, string s)
    {
        var count = new int[26];
        foreach (var c in s)
        {
            count[c - 'a']++;
        }

        var sb = new StringBuilder();
        foreach (var c in order)
        {
            while (count[c - 'a']-- > 0)
            {
                sb.Append(c);
            }
        }

        for (var i = 0; i < 26; i++)
        {
            while (count[i]-- > 0)
            {
                sb.Append((char)(i + 'a'));
            }
        }

        return sb.ToString();
    }
}

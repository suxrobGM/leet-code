using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1961
{
    /// <summary>
    /// 1961. Check If String Is a Prefix of Array - Easy
    /// <a href="https://leetcode.com/problems/check-if-string-is-a-prefix-of-array">See the problem</a>
    /// </summary>
    public bool IsPrefixString(string s, string[] words)
    {
        var sb = new StringBuilder();
        foreach (var word in words)
        {
            sb.Append(word);
            if (sb.Length == s.Length)
            {
                return sb.ToString() == s;
            }
            else if (sb.Length > s.Length)
            {
                return false;
            }
        }
        return false;
    }
}

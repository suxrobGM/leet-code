using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution541
{
    /// <summary>
    /// 541. Reverse String II - Easy
    /// <a href="https://leetcode.com/problems/reverse-string-ii">See the problem</a>
    /// </summary>
    public string ReverseStr(string s, int k)
    {
        var sb = new StringBuilder();
        var reverse = true;
        for (var i = 0; i < s.Length; i += k)
        {
            var start = i;
            var end = Math.Min(i + k, s.Length);
            var length = end - start;
            if (reverse)
            {
                for (var j = end - 1; j >= start; j--)
                {
                    sb.Append(s[j]);
                }
            }
            else
            {
                sb.Append(s.Substring(start, length));
            }

            reverse = !reverse;
        }

        return sb.ToString();
    }
}

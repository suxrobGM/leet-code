using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1957
{
    /// <summary>
    /// 1957. Delete Characters to Make Fancy String - Easy
    /// <a href="https://leetcode.com/problems/delete-characters-to-make-fancy-string">See the problem</a>
    /// </summary>
    public string MakeFancyString(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        var result = new StringBuilder();
        result.Append(s[0]);

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1] && i > 1 && s[i] == s[i - 2])
            {
                continue;
            }

            result.Append(s[i]);
        }

        return result.ToString();
    }
}

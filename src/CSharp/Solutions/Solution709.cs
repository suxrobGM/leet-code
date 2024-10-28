using System.Text;

namespace LeetCode.Solutions;

public class Solution709
{
    /// <summary>
    /// 709. To Lower Case - Easy
    /// <a href="https://leetcode.com/problems/to-lower-case">See the problem</a>
    /// </summary>
    public string ToLowerCase(string s)
    {
        var result = new StringBuilder(s.Length);

        foreach (var c in s)
        {
            if (c >= 'A' && c <= 'Z')
            {
                result.Append((char)(c + 32));
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}

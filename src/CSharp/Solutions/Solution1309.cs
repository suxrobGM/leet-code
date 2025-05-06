using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1309
{
    /// <summary>
    /// 1309. Decrypt String from Alphabet to Integer Mapping - Easy
    /// <a href="https://leetcode.com/problems/verbal-arithmetic-puzzle">See the problem</a>
    /// </summary>
    public string FreqAlphabets(string s)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 2 < s.Length && s[i + 2] == '#')
            {
                sb.Append((char)('a' + int.Parse(s.Substring(i, 2)) - 1));
                i += 2;
            }
            else
            {
                sb.Append((char)('a' + int.Parse(s[i].ToString()) - 1));
            }
        }
        return sb.ToString();
    }
}

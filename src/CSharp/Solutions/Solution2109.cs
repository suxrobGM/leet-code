using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2109
{
    /// <summary>
    /// 2109. Adding Spaces to a String - Medium
    /// <a href="https://leetcode.com/problems/adding-spaces-to-a-string">See the problem</a>
    /// </summary>
    public string AddSpaces(string s, int[] spaces)
    {
        var sb = new StringBuilder(s.Length + spaces.Length);
        var j = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (j < spaces.Length && i == spaces[j])
            {
                sb.Append(' ');
                j++;
            }
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}

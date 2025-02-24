using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1021
{
    /// <summary>
    /// 1021. Remove Outermost Parentheses - Easy
    /// <a href="https://leetcode.com/problems/remove-outermost-parentheses</a>
    /// </summary>
    public string RemoveOuterParentheses(string s)
    {
        var result = new StringBuilder();
        var opened = 0;
        foreach (var c in s)
        {
            if (c == '(' && opened++ > 0)
            {
                result.Append(c);
            }
            if (c == ')' && opened-- > 1)
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}

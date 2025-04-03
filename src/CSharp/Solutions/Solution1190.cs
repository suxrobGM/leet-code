using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1190
{
    /// <summary>
    /// 1190. Reverse Substrings Between Each Pair of Parentheses - Medium
    /// <a href="https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses">See the problem</a>
    /// </summary>
    public string ReverseParentheses(string s)
    {
        var stack = new Stack<StringBuilder>();
        var current = new StringBuilder();

        foreach (char c in s)
        {
            if (c == '(')
            {
                // Push current string and start a new one
                stack.Push(current);
                current = new StringBuilder();
            }
            else if (c == ')')
            {
                // Reverse current and append to top of stack
                var reversed = new StringBuilder(current.ToString());
                reversed = ReverseStringBuilder(reversed);
                current = stack.Pop().Append(reversed);
            }
            else
            {
                current.Append(c);
            }
        }

        return current.ToString();
    }

    private StringBuilder ReverseStringBuilder(StringBuilder sb)
    {
        int left = 0, right = sb.Length - 1;
        while (left < right)
        {
            (sb[right], sb[left]) = (sb[left], sb[right]);
            left++;
            right--;
        }
        return sb;
    }
}

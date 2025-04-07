using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1209
{
    /// <summary>
    /// 1209. Remove All Adjacent Duplicates in String II - Medium
    /// <a href="https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii">See the problem</a>
    /// </summary>
    public string RemoveDuplicates(string s, int k)
    {
        var stack = new Stack<(char ch, int count)>();

        foreach (char c in s)
        {
            if (stack.Count > 0 && stack.Peek().ch == c)
            {
                var top = stack.Pop();
                if (top.count + 1 < k)
                {
                    stack.Push((c, top.count + 1));
                }
                // else: do not push — we just removed k characters
            }
            else
            {
                stack.Push((c, 1));
            }
        }

        var sb = new StringBuilder();
        foreach (var (ch, count) in stack)
        {
            sb.Insert(0, new string(ch, count));
        }

        return sb.ToString();
    }
}

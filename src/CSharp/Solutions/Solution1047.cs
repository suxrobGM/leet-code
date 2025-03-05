using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1047
{
    /// <summary>
    /// 1047. Remove All Adjacent Duplicates In String - Easy
    /// <a href="https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string</a>
    /// </summary>
    public string RemoveDuplicates(string s)
    {
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (stack.Count > 0 && stack.Peek() == c)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        var sb = new StringBuilder();
        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop());
        }

        return sb.ToString();
    }
}

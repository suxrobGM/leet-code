using System.Text;

namespace LeetCode.Solutions;

public class Solution71
{
    /// <summary>
    /// 71. Simplify Path - Medium
    /// <a href="https://leetcode.com/problems/simplify-path">See the problem</a>
    /// </summary>
    public string SimplifyPath(string path)
    {
        var stack = new Stack<string>();
        var parts = path.Split('/');

        foreach (var part in parts)
        {
            if (part == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (part != "." && part != "")
            {
                stack.Push(part);
            }
        }

        var result = new StringBuilder();
        foreach (var part in stack)
        {
            result.Insert(0, $"/{part}");
        }

        return result.Length == 0 ? "/" : result.ToString();
    }
}

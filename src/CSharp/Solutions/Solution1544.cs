using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1544
{
    /// <summary>
    /// 1544. Make The String Great - Easy
    /// <a href="https://leetcode.com/problems/make-the-string-great">See the problem</a>
    /// </summary>
    public string MakeGood(string s)
    {
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (stack.Count > 0 && char.ToLower(stack.Peek()) == char.ToLower(c) && stack.Peek() != c)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        return new string([.. stack.ToArray().Reverse()]);
    }
}

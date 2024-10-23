using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution678
{
    /// <summary>
    /// 678. Valid Parenthesis String - Medium
    /// <a href="https://leetcode.com/problems/valid-parenthesis-string">See the problem</a>
    /// </summary>
    public bool CheckValidString(string s)
    {
        var leftStack = new Stack<int>();
        var starStack = new Stack<int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftStack.Push(i);
            }
            else if (s[i] == '*')
            {
                starStack.Push(i);
            }
            else
            {
                if (leftStack.Count == 0 && starStack.Count == 0)
                {
                    return false;
                }

                if (leftStack.Count > 0)
                {
                    leftStack.Pop();
                }
                else
                {
                    starStack.Pop();
                }
            }
        }

        while (leftStack.Count > 0 && starStack.Count > 0)
        {
            if (leftStack.Peek() > starStack.Peek())
            {
                return false;
            }

            leftStack.Pop();
            starStack.Pop();
        }

        return leftStack.Count == 0;
    }
}

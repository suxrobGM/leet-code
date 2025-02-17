using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1003
{
    /// <summary>
    /// 1003. Check If Word Is Valid After Substitutions - Medium
    /// <a href="https://leetcode.com/problems/check-if-word-is-valid-after-substitutions</a>
    /// </summary>
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == 'c')
            {
                if (stack.Count < 2 || stack.Pop() != 'b' || stack.Pop() != 'a')
                    return false;
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}

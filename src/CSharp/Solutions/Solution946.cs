using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution946
{
    /// <summary>
    /// 946. Validate Stack Sequences - Medium
    /// <a href="https://leetcode.com/problems/validate-stack-sequences">See the problem</a>
    /// </summary>
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var stack = new Stack<int>();
        int i = 0;

        foreach (var x in pushed)
        {
            stack.Push(x);

            while (stack.Count > 0 && stack.Peek() == popped[i])
            {
                stack.Pop();
                i++;
            }
        }

        return stack.Count == 0;
    }
}

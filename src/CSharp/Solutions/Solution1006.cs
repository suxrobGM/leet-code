using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1006
{
    /// <summary>
    /// 1006. Clumsy Factorial - Medium
    /// <a href="https://leetcode.com/problems/clumsy-factorial</a>
    /// </summary>
    public int Clumsy(int n)
    {
        var stack = new Stack<int>();
        stack.Push(n--);

        var i = 0;
        while (n > 0)
        {
            if (i % 4 == 0)
            {
                stack.Push(stack.Pop() * n);
            }
            else if (i % 4 == 1)
            {
                stack.Push(stack.Pop() / n);
            }
            else if (i % 4 == 2)
            {
                stack.Push(n);
            }
            else
            {
                stack.Push(-n);
            }

            i++;
            n--;
        }

        var result = 0;
        while (stack.Count > 0)
        {
            result += stack.Pop();
        }

        return result;
    }
}

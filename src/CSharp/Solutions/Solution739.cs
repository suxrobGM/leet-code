using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution739
{
    /// <summary>
    /// 739. Daily Temperatures - Medium
    /// <a href="https://leetcode.com/problems/daily-temperatures">See the problem</a>
    /// </summary>
    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];

        for (var i = temperatures.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && temperatures[i] >= temperatures[stack.Peek()])
            {
                stack.Pop();
            }

            result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
            stack.Push(i);
        }

        return result;
    }
}

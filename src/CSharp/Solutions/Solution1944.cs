using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1944
{
    /// <summary>
    /// 1944. Number of Visible People in a Queue - Hard
    /// <a href="https://leetcode.com/problems/number-of-visible-people-in-a-queue">See the problem</a>
    /// </summary>
    public int[] CanSeePersonsCount(int[] heights)
    {
        var stack = new Stack<int>();
        var result = new int[heights.Length];

        for (int i = heights.Length - 1; i >= 0; i--)
        {
            var count = 0;

            while (stack.Count > 0 && stack.Peek() <= heights[i])
            {
                stack.Pop();
                count++;
            }

            result[i] = stack.Count > 0 ? count + 1 : count;
            stack.Push(heights[i]);
        }

        return result;
    }
}

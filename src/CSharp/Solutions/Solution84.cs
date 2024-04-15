using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution84
{
    /// <summary>
    /// 84. Largest Rectangle in Histogram - Medium
    /// <a href="https://leetcode.com/problems/largest-rectangle-in-histogram">See the problem</a>
    /// </summary>
    public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int>();
        var maxArea = 0;

        for (var i = 0; i <= heights.Length; i++)
        {
            var currentHeight = i == heights.Length ? 0 : heights[i];

            while (stack.Count > 0 && heights[stack.Peek()] > currentHeight)
            {
                var height = heights[stack.Pop()];
                var width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            stack.Push(i);
        }

        return maxArea;
    }
}

namespace LeetCode.Solutions;

public class Solution85
{
    /// <summary>
    /// 85. Maximal Rectangle - Hard
    /// <a href="https://leetcode.com/problems/maximal-rectangle">See the problem</a>
    /// </summary>
    public int MaximalRectangle(char[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return 0;
        }
        
        var maxArea = 0;
        var heights = new int[matrix[0].Length];

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                // Update the heights for histogram
                heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;
            }

            // Calculate the max area for the current histogram
            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }

        return maxArea;
    }

    private int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int>();
        var maxArea = 0;
        var n = heights.Length;

        for (var i = 0; i <= n; i++)
        {
            var h = (i == n) ? 0 : heights[i];
            while (stack.Count > 0 && h < heights[stack.Peek()])
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

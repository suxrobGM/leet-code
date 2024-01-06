namespace LeetCode.Solutions;

public class Solution11
{
    /// <summary>
    /// Problem #11
    /// <a href="https://leetcode.com/problems/container-with-most-water/">See the problem</a>
    /// </summary>
    public int MaxArea(int[] height)
    {
        var maxArea = 0;
        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var width = right - left;
            var minHeight = Math.Min(height[left], height[right]);
            maxArea = Math.Max(maxArea, width * minHeight);

            // Move the pointer pointing to the shorter line towards the other end
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}

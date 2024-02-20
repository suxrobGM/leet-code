namespace LeetCode.Solutions;

public class Solution42
{
    /// <summary>
    /// 42. Trapping Rain Water
    /// <a href="https://leetcode.com/problems/trapping-rain-water">See the problem</a>
    /// </summary>
    public int Trap(int[] height)
    {
        var n = height.Length;
        var leftMax = new int[n]; // Arrays to store maximum height to the left and right of each index
        var rightMax = new int[n];
        var water = 0;

        leftMax[0] = height[0];
        for (var i = 1; i < n; i++) 
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        rightMax[n - 1] = height[n - 1];
        for (var i = n - 2; i >= 0; i--) 
        {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }

        for (var i = 0; i < n; i++) 
        {
            water += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return water;
    }
}

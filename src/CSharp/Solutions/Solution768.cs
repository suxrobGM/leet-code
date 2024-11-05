using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution768
{
    /// <summary>
    /// 768. Max Chunks To Make Sorted II - Hard
    /// <a href="https://leetcode.com/problems/max-chunks-to-make-sorted-ii">See the problem</a>
    /// </summary>
    public int MaxChunksToSorted(int[] arr)
    {
        var n = arr.Length;
        var leftMax = new int[n];
        var rightMin = new int[n];

        leftMax[0] = arr[0];
        for (var i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], arr[i]);
        }

        rightMin[n - 1] = arr[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            rightMin[i] = Math.Min(rightMin[i + 1], arr[i]);
        }

        var result = 1;
        for (var i = 0; i < n - 1; i++)
        {
            if (leftMax[i] <= rightMin[i + 1])
            {
                result++;
            }
        }

        return result;
    }
}

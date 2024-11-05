using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution769
{
    /// <summary>
    /// 769. Max Chunks To Make Sorted - Medium
    /// <a href="https://leetcode.com/problems/max-chunks-to-make-sorted">See the problem</a>
    /// </summary>
    public int MaxChunksToSorted(int[] arr)
    {
        var n = arr.Length;
        var result = 0;
        var max = 0;
        for (var i = 0; i < n; i++)
        {
            max = Math.Max(max, arr[i]);
            if (max == i)
            {
                result++;
            }
        }

        return result;
    }
}

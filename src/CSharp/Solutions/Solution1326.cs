using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1326
{
    /// <summary>
    /// 1326. Minimum Number of Taps to Open to Water a Garden - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-taps-to-open-to-water-a-garden">See the problem</a>
    /// </summary>
    public int MinTaps(int n, int[] ranges)
    {
        int[] maxReach = new int[n + 1];
        for (int i = 0; i < ranges.Length; i++)
        {
            int left = Math.Max(0, i - ranges[i]);
            int right = Math.Min(n, i + ranges[i]);
            maxReach[left] = Math.Max(maxReach[left], right);
        }

        int taps = 0, currentEnd = 0, farthest = 0;
        for (int i = 0; i < n; i++)
        {
            farthest = Math.Max(farthest, maxReach[i]);
            if (i == currentEnd)
            {
                taps++;
                currentEnd = farthest;
                if (currentEnd >= n) break;
            }
            if (farthest <= i) return -1; // Not possible to reach further
        }

        return taps;
    }
}

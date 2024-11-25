using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution849
{
    /// <summary>
    /// 849. Maximize Distance to Closest Person - Medium
    /// <a href="https://leetcode.com/problems/shifting-letters">See the problem</a>
    /// </summary>
    public int MaxDistToClosest(int[] seats)
    {
        var n = seats.Length;
        var left = new int[n];
        var right = new int[n];
        var maxDistance = 0;

        for (var i = 0; i < n; i++)
        {
            left[i] = seats[i] == 1 ? 0 : (i == 0 ? n : left[i - 1] + 1);
        }

        for (var i = n - 1; i >= 0; i--)
        {
            right[i] = seats[i] == 1 ? 0 : (i == n - 1 ? n : right[i + 1] + 1);
        }

        for (var i = 0; i < n; i++)
        {
            if (seats[i] == 0)
            {
                maxDistance = Math.Max(maxDistance, Math.Min(left[i], right[i]));
            }
        }

        return maxDistance;
    }
}

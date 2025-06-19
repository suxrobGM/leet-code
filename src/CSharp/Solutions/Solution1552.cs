using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1552
{
    /// <summary>
    /// 1552. Magnetic Force Between Two Balls - Medium
    /// <a href="https://leetcode.com/problems/magnetic-force-between-two-balls">See the problem</a>
    /// </summary>
    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);
        int left = 1, right = position[^1] - position[0];
        int result = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanPlaceBalls(position, m, mid))
            {
                result = mid; // Found a valid distance
                left = mid + 1; // Try for a larger distance
            }
            else
            {
                right = mid - 1; // Try for a smaller distance
            }
        }

        return result;
    }

    private bool CanPlaceBalls(int[] position, int m, int distance)
    {
        int count = 1; // Place the first ball at the first position
        int lastPosition = position[0];

        for (int i = 1; i < position.Length; i++)
        {
            if (position[i] - lastPosition >= distance)
            {
                count++;
                lastPosition = position[i];
                if (count == m) return true; // All balls placed successfully
            }
        }

        return false; // Not enough balls placed
    }
}

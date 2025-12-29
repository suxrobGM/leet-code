using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1964
{
    /// <summary>
    /// 1964. Find the Longest Valid Obstacle Course at Each Position - Hard
    /// <a href="https://leetcode.com/problems/find-the-longest-valid-obstacle-course-at-each-position">See the problem</a>
    /// </summary>
    public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
    {
        int n = obstacles.Length;
        int[] result = new int[n];
        var lis = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int obstacle = obstacles[i];
            int pos = UpperBound(lis, obstacle);
            if (pos == lis.Count)
            {
                lis.Add(obstacle);
            }
            else
            {
                lis[pos] = obstacle;
            }
            result[i] = pos + 1;
        }

        return result;
    }

    private int UpperBound(List<int> lis, int target)
    {
        int left = 0;
        int right = lis.Count;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (lis[mid] <= target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}

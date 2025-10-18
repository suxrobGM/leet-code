using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1870
{
    /// <summary>
    /// 1870. Minimum Speed to Arrive on Time - Medium
    /// <a href="https://leetcode.com/problems/minimum-speed-to-arrive-on-time">See the problem</a>
    /// </summary>
    public int MinSpeedOnTime(int[] dist, double hour)
    {
        int left = 1;
        int right = 10000000;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanArriveOnTime(dist, hour, mid))
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }

    private bool CanArriveOnTime(int[] dist, double hour, int speed)
    {
        double time = 0.0;
        int n = dist.Length;

        for (int i = 0; i < n - 1; i++)
        {
            time += Math.Ceiling((double)dist[i] / speed);
        }

        time += (double)dist[n - 1] / speed;

        return time <= hour;
    }
}

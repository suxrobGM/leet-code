namespace LeetCode.Solutions;

public class Solution2187
{
    /// <summary>
    /// 2186. Minimum Time to Complete Trips - Medium
    /// <a href="https://leetcode.com/problems/minimum-time-to-complete-trips">See the problem</a>
    /// </summary>
    public long MinimumTime(int[] time, int totalTrips)
    {
        long left = 1;
        long right = (long)totalTrips * time.Max();

        while (left < right)
        {
            long mid = left + (right - left) / 2;
            long trips = 0;

            foreach (var t in time)
            {
                trips += mid / t;
            }

            if (trips >= totalTrips)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}

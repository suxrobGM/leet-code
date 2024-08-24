namespace LeetCode.Solutions;

public class Solution495
{
    /// <summary>
    /// 495. Teemo Attacking - Medium
    /// <a href="https://leetcode.com/problems/teemo-attacking">See the problem</a>
    /// </summary>
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        if (timeSeries.Length == 0)
        {
            return 0;
        }

        int totalDuration = 0;
        for (int i = 1; i < timeSeries.Length; i++)
        {
            totalDuration += Math.Min(timeSeries[i] - timeSeries[i - 1], duration);
        }

        return totalDuration + duration;
    }
}

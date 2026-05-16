namespace LeetCode.Solutions;

public class Solution2136
{
    /// <summary>
    /// 2136. Earliest Possible Day of Full Bloom - Hard
    /// <a href="https://leetcode.com/problems/earliest-possible-day-of-full-bloom">See the problem</a>
    /// </summary>
    public int EarliestFullBloom(int[] plantTime, int[] growTime)
    {
        int n = plantTime.Length;
        int[] indices = new int[n];
        for (int i = 0; i < n; i++) indices[i] = i;

        // Sort by grow time in descending order
        Array.Sort(indices, (a, b) => growTime[b].CompareTo(growTime[a]));

        int currentDay = 0;
        int earliestFullBloom = 0;

        foreach (int index in indices)
        {
            currentDay += plantTime[index];
            earliestFullBloom = Math.Max(earliestFullBloom, currentDay + growTime[index]);
        }

        return earliestFullBloom;
    }
}

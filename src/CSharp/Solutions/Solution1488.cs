using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1488
{
    /// <summary>
    /// 1488. Avoid Flood in The City - Medium
    /// <a href="https://leetcode.com/problems/avoid-flood-in-the-city">See the problem</a>
    /// </summary>
    public int[] AvoidFlood(int[] rains)
    {
        int n = rains.Length;
        var result = new int[n];
        var lakeToLastDay = new Dictionary<int, int>();
        var dryDays = new SortedSet<int>();

        for (int i = 0; i < n; i++)
        {
            int lake = rains[i];
            if (lake == 0)
            {
                dryDays.Add(i);
                result[i] = 1; // Will be overwritten if used to dry a specific lake
            }
            else
            {
                result[i] = -1;
                if (lakeToLastDay.ContainsKey(lake))
                {
                    int lastRainDay = lakeToLastDay[lake];

                    // Try to find the first dry day after lastRainDay
                    int dryDayToUse = -1;
                    foreach (int dryDay in dryDays)
                    {
                        if (dryDay > lastRainDay)
                        {
                            dryDayToUse = dryDay;
                            break;
                        }
                    }

                    if (dryDayToUse == -1)
                    {
                        // No available dry day -> Flood will occur
                        return [];
                    }

                    result[dryDayToUse] = lake; // Dry this lake
                    dryDays.Remove(dryDayToUse); // Mark dry day as used
                }

                lakeToLastDay[lake] = i; // Update last rainy day for this lake
            }
        }

        return result;
    }
}

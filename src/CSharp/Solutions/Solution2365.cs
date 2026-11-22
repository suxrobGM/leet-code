namespace LeetCode.Solutions;

public class Solution2365
{
    /// <summary>
    /// 2365. Task Scheduler II - Medium
    /// <a href="https://leetcode.com/problems/task-scheduler-ii">See the problem</a>
    /// </summary>
    public long TaskSchedulerII(int[] tasks, int space)
    {
        var nextAvailableDays = new Dictionary<int, long>();
        long day = 0;

        foreach (int task in tasks)
        {
            nextAvailableDays.TryGetValue(task, out long nextAvailableDay);
            day = Math.Max(day + 1, nextAvailableDay);
            nextAvailableDays[task] = day + space + 1;
        }

        return day;
    }
}

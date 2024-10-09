using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution621
{
    /// <summary>
    /// 621. Task Scheduler - Medium
    /// <a href="https://leetcode.com/problems/task-scheduler">See the problem</a>
    /// </summary>
    public int LeastInterval(char[] tasks, int n)
    {
        var taskCount = new int[26];
        foreach (var task in tasks)
        {
            taskCount[task - 'A']++;
        }
        
        Array.Sort(taskCount);
        var maxTaskCount = taskCount[^1] - 1;
        var idleSlots = maxTaskCount * n;

        for (var i = 24; i >= 0 && taskCount[i] > 0; i--)
        {
            idleSlots -= Math.Min(maxTaskCount, taskCount[i]);
        }
        return idleSlots > 0 ? idleSlots + tasks.Length : tasks.Length;
    }
}

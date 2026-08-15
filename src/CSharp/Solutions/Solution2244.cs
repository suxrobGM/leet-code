namespace LeetCode.Solutions;

public class Solution2244
{
    /// <summary>
    /// 2244. Minimum Rounds to Complete All Tasks - Medium
    /// <a href="https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks">See the problem</a>
    /// </summary>
    public int MinimumRounds(int[] tasks)
    {
        var taskCounts = new Dictionary<int, int>();
        foreach (var task in tasks)
        {
            if (!taskCounts.ContainsKey(task))
            {
                taskCounts[task] = 0;
            }
            taskCounts[task]++;
        }

        var rounds = 0;
        foreach (var count in taskCounts.Values)
        {
            if (count == 1)
            {
                return -1; // Impossible to complete this task
            }
            rounds += (count + 2) / 3; // Minimum rounds needed for this task
        }

        return rounds;
    }
}

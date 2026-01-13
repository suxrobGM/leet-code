namespace LeetCode.Solutions;

public class Solution1986
{
    /// <summary>
    /// 1986. Minimum Number of Work Sessions to Finish the Tasks - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-work-sessions-to-finish-the-tasks">See the problem</a>
    /// </summary>
    public int MinSessions(int[] tasks, int sessionTime)
    {
        int n = tasks.Length;
        int fullMask = (1 << n) - 1;

        // Sort tasks in descending order for better optimization
        Array.Sort(tasks);
        Array.Reverse(tasks);

        // dp[mask] = (minSessions, remainingTimeInLastSession)
        var dp = new (int sessions, int remaining)[1 << n];

        // Initialize with worst case
        for (int i = 0; i <= fullMask; i++)
        {
            dp[i] = (n + 1, 0);
        }

        // Base case: no tasks assigned, 1 session with full time
        dp[0] = (1, sessionTime);

        // Process all masks in order
        for (int mask = 0; mask <= fullMask; mask++)
        {
            if (dp[mask].sessions > n) continue;

            var (currSessions, currRemaining) = dp[mask];

            // Try adding each unassigned task
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0) continue; // Task already assigned

                int newMask = mask | (1 << i);
                int newSessions, newRemaining;

                if (tasks[i] <= currRemaining)
                {
                    // Task fits in current session
                    newSessions = currSessions;
                    newRemaining = currRemaining - tasks[i];
                }
                else
                {
                    // Need to start a new session
                    newSessions = currSessions + 1;
                    newRemaining = sessionTime - tasks[i];
                }

                // Update if this state is better
                // Prefer fewer sessions, or same sessions with more remaining time
                if (newSessions < dp[newMask].sessions ||
                    (newSessions == dp[newMask].sessions &&
                     newRemaining > dp[newMask].remaining))
                {
                    dp[newMask] = (newSessions, newRemaining);
                }
            }
        }

        return dp[fullMask].sessions;
    }
}

using System.Text;

namespace LeetCode.Solutions;

public class Solution1817
{
    /// <summary>
    /// 1817. Finding the Users Active Minutes - Medium
    /// <a href="https://leetcode.com/problems/finding-the-users-active-minutes">See the problem</a>
    /// </summary>
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var userActivity = new Dictionary<int, HashSet<int>>();

        foreach (var log in logs)
        {
            var userId = log[0];
            var minute = log[1];

            if (!userActivity.ContainsKey(userId))
            {
                userActivity[userId] = new HashSet<int>();
            }
            userActivity[userId].Add(minute);
        }

        var activeMinutes = new int[k];
        foreach (var activity in userActivity.Values)
        {
            var count = activity.Count;
            if (count > 0 && count <= k)
            {
                activeMinutes[count - 1]++;
            }
        }

        return activeMinutes;
    }
}

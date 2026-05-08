namespace LeetCode.Solutions;

public class Solution2127
{
    /// <summary>
    /// 2127. Maximum Employees to Be Invited to a Meeting - Hard
    /// <a href="https://leetcode.com/problems/maximum-employees-to-be-invited-to-a-meeting">See the problem</a>
    /// </summary>
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        var inDegree = new int[n];
        for (int i = 0; i < n; i++)
        {
            inDegree[favorite[i]]++;
        }

        var chain = new int[n];
        var visited = new bool[n];
        var queue = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            visited[node] = true;
            int next = favorite[node];
            chain[next] = Math.Max(chain[next], chain[node] + 1);
            if (--inDegree[next] == 0)
            {
                queue.Enqueue(next);
            }
        }

        int longestCycle = 0;
        int twoCycleSum = 0;
        for (int i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }

            int length = 0;
            int curr = i;
            while (!visited[curr])
            {
                visited[curr] = true;
                curr = favorite[curr];
                length++;
            }

            if (length == 2)
            {
                twoCycleSum += 2 + chain[i] + chain[favorite[i]];
            }
            else
            {
                longestCycle = Math.Max(longestCycle, length);
            }
        }

        return Math.Max(longestCycle, twoCycleSum);
    }
}

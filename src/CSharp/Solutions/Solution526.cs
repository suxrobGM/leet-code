using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution526
{
    /// <summary>
    /// 526. Beautiful Arrangement - Medium
    /// <a href="https://leetcode.com/problems/beautiful-arrangement">See the problem</a>
    /// </summary>
    public int CountArrangement(int n)
    {
        var visited = new bool[n + 1];
        return CountArrangement(visited, 1);
    }

    private int CountArrangement(bool[] visited, int pos)
    {
        if (pos == visited.Length)
        {
            return 1;
        }

        int count = 0;
        for (int i = 1; i < visited.Length; i++)
        {
            if (!visited[i] && (i % pos == 0 || pos % i == 0))
            {
                visited[i] = true;
                count += CountArrangement(visited, pos + 1);
                visited[i] = false;
            }
        }

        return count;
    }
}

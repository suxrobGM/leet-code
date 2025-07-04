using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1583
{
    /// <summary>
    /// 1583. Count Unhappy Friends - Medium
    /// <a href="https://leetcode.com/problems/count-unhappy-friends">See the problem</a>
    /// </summary>
    public int CountUnhappyFriends(int n, int[][] preferences, int[][] pairs)
    {
        // Map to store the ranking of friends
        var rank = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < preferences[i].Length; j++)
            {
                rank[i, preferences[i][j]] = j;
            }
        }

        // Pair mapping
        var pair = new int[n];
        foreach (var p in pairs)
        {
            pair[p[0]] = p[1];
            pair[p[1]] = p[0];
        }

        var unhappy = new bool[n];

        for (int x = 0; x < n; x++)
        {
            int y = pair[x];
            int idx = Array.IndexOf(preferences[x], y);
            // All friends more preferred than current pair
            for (int i = 0; i < idx; i++)
            {
                int u = preferences[x][i];
                int v = pair[u];
                // Check if u prefers x over their pair v
                if (rank[u, x] < rank[u, v])
                {
                    unhappy[x] = true;
                    break;
                }
            }
        }

        return unhappy.Count(b => b);
    }
}

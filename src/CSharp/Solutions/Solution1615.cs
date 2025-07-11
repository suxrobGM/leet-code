using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1615
{
    /// <summary>
    /// 1615. Maximal Network Rank - Medium
    /// <a href="https://leetcode.com/problems/maximal-network-rank">See the problem</a>
    /// </summary>
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        int[] degree = new int[n];
        var roadSet = new HashSet<(int, int)>();

        foreach (var road in roads)
        {
            int u = road[0];
            int v = road[1];
            degree[u]++;
            degree[v]++;
            roadSet.Add((Math.Min(u, v), Math.Max(u, v)));
        }

        int maxRank = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int currentRank = degree[i] + degree[j];
                if (roadSet.Contains((i, j)))
                {
                    currentRank--;
                }
                maxRank = Math.Max(maxRank, currentRank);
            }
        }

        return maxRank;
    }
}

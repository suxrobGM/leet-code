using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1319
{
    /// <summar
    /// 1319. Number of Operations to Make Network Connected - Medium
    /// <a href="https://leetcode.com/problems/number-of-operations-to-make-network-connected">See the problem</a>
    /// </summary>
    public int MakeConnected(int n, int[][] connections)
    {
        if (connections.Length < n - 1)
        {
            return -1;
        } // Not enough connections to connect all computers

        var parent = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                parent[rootX] = rootY;
            }
        }

        foreach (var connection in connections)
        {
            Union(connection[0], connection[1]);
        }

        var components = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            components.Add(Find(i));
        }

        return components.Count - 1;
    }
}

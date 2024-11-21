using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution839
{
    /// <summary>
    /// 839. Similar String Groups - Hard
    /// <a href="https://leetcode.com/problems/similar-string-groups">See the problem</a>
    /// </summary>
    public int NumSimilarGroups(string[] strs)
    {
        var n = strs.Length;

        // Union-Find data structure
        var parent = new int[n];
        for (var i = 0; i < n; i++)
        {
            parent[i] = i;
        }

        // Find operation with path compression
        int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        // Union operation
        void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                parent[rootX] = rootY;
            }
        }

        // Check if two strings are similar
        bool IsSimilar(string a, string b)
        {
            int diffCount = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    diffCount++;
                    if (diffCount > 2) return false;
                }
            }
            return diffCount == 2 || diffCount == 0;
        }

        // Process all pairs of strings
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (IsSimilar(strs[i], strs[j]))
                {
                    Union(i, j);
                }
            }
        }

        // Count distinct groups
        int groups = 0;
        for (int i = 0; i < n; i++)
        {
            if (Find(i) == i) groups++;
        }

        return groups;
    }
}

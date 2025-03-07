using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1061
{
    private readonly int[] parent = new int[26];

    /// <summary>
    /// 1061. Lexicographically Smallest Equivalent String - Medium
    /// <a href="https://leetcode.com/problems/lexicographically-smallest-equivalent-string"</a>
    /// </summary>
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        // Initialize Union-Find structure
        for (int i = 0; i < 26; i++)
        {
            parent[i] = i;
        }

        // Union operation to group equivalent characters
        for (int i = 0; i < s1.Length; i++)
        {
            int char1 = s1[i] - 'a';
            int char2 = s2[i] - 'a';

            Union(char1, char2);
        }

        // Transform baseStr using the smallest equivalent characters
        char[] result = new char[baseStr.Length];
        for (int i = 0; i < baseStr.Length; i++)
        {
            int root = Find(baseStr[i] - 'a');
            result[i] = (char)('a' + root);
        }

        return new string(result);
    }

    // Find operation with path compression for efficiency
    private int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]); // Path compression
        }
        return parent[x];
    }

    // Union operation to merge two groups
    private void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        // Assign the smaller character as the parent for lexicographical order
        if (rootX < rootY)
        {
            parent[rootY] = rootX;
        }
        else
        {
            parent[rootX] = rootY;
        }
    }
}

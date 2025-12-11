using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1938
{
    private record TrieNode
    {
        public TrieNode[] children = new TrieNode[2];
        public int count = 0; // Track how many numbers use this path
    }

    /// <summary>
    /// 1938. Maximum Genetic Difference Query - Hard
    /// <a href="https://leetcode.com/problems/maximum-genetic-difference-query">See the problem</a>
    /// </summary>
    public int[] MaxGeneticDifference(int[] parents, int[][] queries)
    {
        int n = parents.Length;

        // Build adjacency list (parent -> children)
        List<int>[] children = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            children[i] = [];
        }

        int root = -1;
        for (int i = 0; i < n; i++)
        {
            if (parents[i] == -1)
            {
                root = i;
            }
            else
            {
                children[parents[i]].Add(i);
            }
        }

        // Group queries by node
        var queryList = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
        {
            queryList[i] = [];
        }

        for (int i = 0; i < queries.Length; i++)
        {
            int node = queries[i][0];
            int val = queries[i][1];
            queryList[node].Add((val, i));
        }

        // Result array
        int[] ans = new int[queries.Length];

        // DFS with Trie
        TrieNode trie = new TrieNode();
        DFS(root, children, queryList, trie, ans);

        return ans;
    }

    private void DFS(int node, List<int>[] children, List<(int, int)>[] queryList, TrieNode trie, int[] ans)
    {
        // Add current node's genetic value to trie
        InsertToTrie(trie, node);

        // Process all queries for this node
        foreach (var (val, queryIdx) in queryList[node])
        {
            ans[queryIdx] = QueryTrie(trie, val);
        }

        // DFS to children
        foreach (int child in children[node])
        {
            DFS(child, children, queryList, trie, ans);
        }

        // Remove current node from trie (backtrack)
        RemoveFromTrie(trie, node);
    }

    private void InsertToTrie(TrieNode root, int num)
    {
        TrieNode cur = root;
        // Insert bits from MSB to LSB (bit 17 to 0, since max value is 2*10^5 < 2^18)
        for (int i = 17; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (cur.children[bit] == null)
            {
                cur.children[bit] = new TrieNode();
            }
            cur.children[bit].count++;
            cur = cur.children[bit];
        }
    }

    private int QueryTrie(TrieNode root, int num)
    {
        TrieNode cur = root;
        int result = 0;

        // Traverse bits from MSB to LSB, greedily choosing opposite bit
        for (int i = 17; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            int opposite = 1 - bit;

            // To maximize XOR, try opposite bit first
            if (cur.children[opposite] != null && cur.children[opposite].count > 0)
            {
                result |= (1 << i); // Set this bit in result
                cur = cur.children[opposite];
            }
            else
            {
                cur = cur.children[bit];
            }
        }
        return result;
    }

    private void RemoveFromTrie(TrieNode root, int num)
    {
        TrieNode cur = root;
        for (int i = 17; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            cur = cur.children[bit];
            cur.count--;
        }
    }
}

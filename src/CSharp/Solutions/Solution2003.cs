namespace LeetCode.Solutions;

public class Solution2003
{
    /// <summary>
    /// 2003. Smallest Missing Genetic Value in Each Subtree - Hard
    /// <a href="https://leetcode.com/problems/smallest-missing-genetic-value-in-each-subtree">See the problem</a>
    /// </summary>
    public int[] SmallestMissingValueSubtree(int[] parents, int[] nums)
    {
        int n = parents.Length;
        int[] result = new int[n];
        Array.Fill(result, 1);

        // Build the tree as an adjacency list
        var tree = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            tree[i] = [];
        }
        for (int i = 1; i < n; i++)
        {
            tree[parents[i]].Add(i);
        }

        // Find the index of the node with genetic value 1
        int indexOfOne = Array.IndexOf(nums, 1);
        if (indexOfOne == -1)
        {
            return result; // If there's no node with value 1, all results remain 1
        }

        // Track which genetic values are present
        HashSet<int> present = [];

        // Track visited nodes to avoid redundant DFS
        bool[] visited = new bool[n];

        // DFS to mark present values in the subtree
        void Dfs(int node)
        {
            if (visited[node]) return;
            visited[node] = true;
            present.Add(nums[node]);
            foreach (var child in tree[node])
            {
                Dfs(child);
            }
        }

        // Start from the node with genetic value 1 and move up to the root
        int minMissing = 1;
        for (int current = indexOfOne; current != -1; current = parents[current])
        {
            // DFS from current node (only unvisited nodes will be processed)
            Dfs(current);

            // Find the smallest missing genetic value starting from previous minMissing
            while (present.Contains(minMissing))
            {
                minMissing++;
            }
            result[current] = minMissing;
        }

        return result;
    }
}

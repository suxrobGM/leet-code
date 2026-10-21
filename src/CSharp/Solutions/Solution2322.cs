namespace LeetCode.Solutions;

public class Solution2322
{
    /// <summary>
    /// 2322. Minimum Score After Removals on a Tree - Hard
    /// <a href="https://leetcode.com/problems/minimum-score-after-removals-on-a-tree">See the problem</a>
    /// </summary>
    public int MinimumScore(int[] nums, int[][] edges)
    {
        var n = nums.Length;
        var graph = new List<int>[n];
        for (var node = 0; node < n; node++)
        {
            graph[node] = new List<int>();
        }

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var subtreeXor = new int[n];
        var entry = new int[n];
        var exit = new int[n];
        var timer = 0;

        void Dfs(int node, int parent)
        {
            entry[node] = timer++;
            subtreeXor[node] = nums[node];

            foreach (var child in graph[node])
            {
                if (child == parent)
                {
                    continue;
                }

                Dfs(child, node);
                subtreeXor[node] ^= subtreeXor[child];
            }

            exit[node] = timer;
        }

        bool IsAncestor(int ancestor, int node) =>
            entry[ancestor] <= entry[node] && entry[node] < exit[ancestor];

        Dfs(0, -1);
        var totalXor = subtreeXor[0];
        var answer = int.MaxValue;

        // Each non-root node represents removing its edge to its parent.
        for (var first = 1; first < n; first++)
        {
            for (var second = first + 1; second < n; second++)
            {
                int a, b, c;
                if (IsAncestor(first, second))
                {
                    // The second subtree is inside the first subtree.
                    a = subtreeXor[second];
                    b = subtreeXor[first] ^ subtreeXor[second];
                    c = totalXor ^ subtreeXor[first];
                }
                else if (IsAncestor(second, first))
                {
                    a = subtreeXor[first];
                    b = subtreeXor[second] ^ subtreeXor[first];
                    c = totalXor ^ subtreeXor[second];
                }
                else
                {
                    // The removed subtrees are disjoint.
                    a = subtreeXor[first];
                    b = subtreeXor[second];
                    c = totalXor ^ a ^ b;
                }

                var score = Math.Max(a, Math.Max(b, c)) - Math.Min(a, Math.Min(b, c));
                answer = Math.Min(answer, score);
                if (answer == 0)
                {
                    return 0;
                }
            }
        }

        return answer;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution863
{
    /// <summary>
    /// 863. All Nodes Distance K in Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree">See the problem</a>
    /// </summary>
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        var graph = new Dictionary<int, List<int>>();
        BuildGraph(root, null, graph);

        var queue = new Queue<int>();
        queue.Enqueue(target.val);

        var visited = new HashSet<int> { target.val };

        while (k > 0 && queue.Count > 0)
        {
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                int node = queue.Dequeue();

                if (graph.ContainsKey(node))
                {
                    foreach (int neighbor in graph[node])
                    {
                        if (visited.Contains(neighbor))
                        {
                            continue;
                        }

                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            k--;
        }

        return [.. queue];
    }

    private void BuildGraph(TreeNode node, TreeNode parent, Dictionary<int, List<int>> graph)
    {
        if (node == null)
        {
            return;
        }

        if (!graph.ContainsKey(node.val))
        {
            graph[node.val] = new List<int>();
        }

        if (parent != null)
        {
            graph[node.val].Add(parent.val);
        }

        if (node.left != null)
        {
            graph[node.val].Add(node.left.val);
            BuildGraph(node.left, node, graph);
        }

        if (node.right != null)
        {
            graph[node.val].Add(node.right.val);
            BuildGraph(node.right, node, graph);
        }
    }
}

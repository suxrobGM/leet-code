using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution987
{
    /// <summary>
    /// 987. Vertical Order Traversal of a Binary Tree - Hard
    /// <a href="https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree">See the problem</a>
    /// </summary>
    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        var result = new List<IList<int>>();
        var map = new Dictionary<int, List<int[]>>();
        var queue = new Queue<(TreeNode, int)>();

        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            var size = queue.Count;
            var tempMap = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < size; i++)
            {
                var (node, x) = queue.Dequeue();

                if (!tempMap.ContainsKey(x))
                {
                    tempMap[x] = new List<int[]>();
                }

                tempMap[x].Add(new int[] { node.val, 0 });

                if (node.left != null)
                {
                    queue.Enqueue((node.left, x - 1));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, x + 1));
                }
            }

            foreach (var kvp in tempMap)
            {
                if (!map.ContainsKey(kvp.Key))
                {
                    map[kvp.Key] = new List<int[]>();
                }

                kvp.Value.Sort((a, b) =>
                {
                    if (a[1] == b[1])
                    {
                        return a[0] - b[0];
                    }

                    return a[1] - b[1];
                });

                map[kvp.Key].AddRange(kvp.Value);
            }
        }

        var keys = map.Keys.ToList();
        keys.Sort();

        foreach (var key in keys)
        {
            var list = new List<int>();

            foreach (var item in map[key])
            {
                list.Add(item[0]);
            }

            result.Add(list);
        }

        return result;
    }
}

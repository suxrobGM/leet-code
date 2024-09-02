using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution515
{
    /// <summary>
    /// 515. Find Largest Value in Each Tree Row - Medium
    /// <a href="https://leetcode.com/problems/find-largest-value-in-each-tree-row">See the problem</a>
    /// </summary>
    public IList<int> LargestValues(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var size = queue.Count;
            var max = int.MinValue;

            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                max = Math.Max(max, node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(max);
        }

        return result;
    }
}

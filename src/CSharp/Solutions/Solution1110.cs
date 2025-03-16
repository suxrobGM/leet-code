using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1110
{
    /// <summary>
    /// 1110. Delete Nodes And Return Forest - Medium
    /// <a href="https://leetcode.com/problems/delete-nodes-and-return-forest">See the problem</a>
    /// </summary>
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        var result = new List<TreeNode>();
        var toDelete = new HashSet<int>(to_delete);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        if (!toDelete.Contains(root.val))
        {
            result.Add(root);
        }
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node.left != null)
            {
                queue.Enqueue(node.left);
                if (toDelete.Contains(node.left.val))
                {
                    node.left = null;
                }
            }
            if (node.right != null)
            {
                queue.Enqueue(node.right);
                if (toDelete.Contains(node.right.val))
                {
                    node.right = null;
                }
            }
            if (toDelete.Contains(node.val))
            {
                if (node.left != null)
                {
                    result.Add(node.left);
                }
                if (node.right != null)
                {
                    result.Add(node.right);
                }
            }
        }
        return result;
    }
}

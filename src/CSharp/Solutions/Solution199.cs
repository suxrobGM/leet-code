using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution199
{
    /// <summary>
    /// 199. Binary Tree Right Side View - Medium
    /// <a href="https://leetcode.com/problems/binary-tree-right-side-view">See the problem</a>
    /// </summary>
    public IList<int> RightSideView(TreeNode root)
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
            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                if (i == size - 1)
                {
                    result.Add(node.val);
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return result;
    }
}

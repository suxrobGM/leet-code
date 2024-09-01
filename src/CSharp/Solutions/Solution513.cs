using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution513
{
    /// <summary>
    /// 513. Find Bottom Left Tree Value - Medium
    /// <a href="https://leetcode.com/problems/find-bottom-left-tree-value">See the problem</a>
    /// </summary>
    public int FindBottomLeftValue(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var result = 0;

        while (queue.Count > 0)
        {
            var size = queue.Count;
            result = queue.Peek().val;

            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();

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

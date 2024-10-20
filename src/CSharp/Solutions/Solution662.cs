using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution662
{
    /// <summary>
    /// 662. Maximum Width of Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/maximum-width-of-binary-tree">See the problem</a>
    /// </summary>
    public int WidthOfBinaryTree(TreeNode root)
    {
        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 0));

        var maxWidth = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var left = queue.Peek().Item2;
            var right = 0;

            for (var i = 0; i < count; i++)
            {
                var (node, pos) = queue.Dequeue();
                right = pos;

                if (node.left != null)
                {
                    queue.Enqueue((node.left, 2 * pos));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, 2 * pos + 1));
                }
            }

            maxWidth = Math.Max(maxWidth, right - left + 1);
        }

        return maxWidth;
    }
}

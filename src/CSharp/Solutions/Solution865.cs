using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution865
{
    /// <summary>
    /// 865. Smallest Subtree with all the Deepest Nodes - Medium
    /// <a href="https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes">See the problem</a>
    /// </summary>
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        return Helper(root).node;
    }

    private (TreeNode node, int depth) Helper(TreeNode node)
    {
        if (node == null)
        {
            return (null, 0);
        }

        var left = Helper(node.left);
        var right = Helper(node.right);

        if (left.depth > right.depth)
        {
            return (left.node, left.depth + 1);
        }
        else if (left.depth < right.depth)
        {
            return (right.node, right.depth + 1);
        }
        else
        {
            return (node, left.depth + 1);
        }
    }
}

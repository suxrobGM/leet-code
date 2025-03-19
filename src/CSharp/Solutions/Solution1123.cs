using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1123
{
    /// <summary>
    /// 1123. Lowest Common Ancestor of Deepest Leaves - Medium
    /// <a href="https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves">See the problem</a>
    /// </summary>
    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        return LcaDeepestLeaves(root, 0).node;
    }

    private (TreeNode node, int depth) LcaDeepestLeaves(TreeNode node, int depth)
    {
        if (node == null)
        {
            return (null, depth);
        }

        var left = LcaDeepestLeaves(node.left, depth + 1);
        var right = LcaDeepestLeaves(node.right, depth + 1);

        if (left.depth == right.depth)
        {
            return (node, left.depth);
        }

        return left.depth > right.depth ? left : right;
    }
}

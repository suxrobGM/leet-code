using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution236
{
    /// <summary>
    /// 236. Lowest Common Ancestor of a Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree">See the problem</a>
    /// </summary>
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)
        {
            return root;
        }

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null)
        {
            return root;
        }

        return left ?? right;
    }
}

using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution572
{
    /// <summary>
    /// 572. Subtree of Another Tree - Easy
    /// <a href="https://leetcode.com/problems/subtree-of-another-tree">See the problem</a>
    /// </summary>
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
        {
            return false;
        }

        if (IsSameTree(root, subRoot))
        {
            return true;
        }

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode root, TreeNode subRoot)
    {
        if (root == null && subRoot == null)
        {
            return true;
        }

        if (root == null || subRoot == null)
        {
            return false;
        }

        return root.val == subRoot.val && IsSameTree(root.left, subRoot.left) && IsSameTree(root.right, subRoot.right);
    }
}

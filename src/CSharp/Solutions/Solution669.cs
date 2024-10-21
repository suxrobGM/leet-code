using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution669
{
    /// <summary>
    /// 669. Trim a Binary Search Tree - Medium
    /// <a href="https://leetcode.com/problems/trim-a-binary-search-tree">See the problem</a>
    /// </summary>
    public TreeNode TrimBST(TreeNode root, int low, int high)
    {
        if (root == null)
        {
            return null;
        }

        if (root.val < low)
        {
            return TrimBST(root.right, low, high);
        }

        if (root.val > high)
        {
            return TrimBST(root.left, low, high);
        }

        root.left = TrimBST(root.left, low, high);
        root.right = TrimBST(root.right, low, high);

        return root;
    }
}

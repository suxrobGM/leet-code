using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution814
{
    /// <summary>
    /// 814. Binary Tree Pruning - Medium
    /// <a href="https://leetcode.com/problems/binary-tree-pruning">See the problem</a>
    /// </summary>
    public TreeNode PruneTree(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);

        if (root.left == null && root.right == null && root.val == 0)
        {
            return null;
        }

        return root;
    }
}

using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution897
{
    /// <summary>
    /// 897. Increasing Order Search Tree - Easy
    /// <a href="https://leetcode.com/problems/increasing-order-search-tree">See the problem</a>
    /// </summary>
    public TreeNode IncreasingBST(TreeNode root)
    {
        var dummy = new TreeNode();
        var current = dummy;

        void InOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.left);

            current.right = new TreeNode(node.val);
            current = current.right;

            InOrder(node.right);
        }

        InOrder(root);

        return dummy.right;
    }
}

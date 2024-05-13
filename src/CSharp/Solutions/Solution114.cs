using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution114
{
    /// <summary>
    /// 114. Flatten Binary Tree to Linked List - Medium
    /// <a href="https://leetcode.com/problems/flatten-binary-tree-to-linked-list">See the problem</a>
    /// </summary>
    public void Flatten(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        Flatten(root.left);
        Flatten(root.right);

        var left = root.left;
        var right = root.right;

        root.left = null;
        root.right = left;

        var current = root;

        while (current.right != null)
        {
            current = current.right;
        }

        current.right = right;
    }
}

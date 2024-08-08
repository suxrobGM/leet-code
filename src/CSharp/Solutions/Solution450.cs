using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution450
{
    /// <summary>
    /// 450. Delete Node in a BST - Medium
    /// <a href="https://leetcode.com/problems/delete-node-in-a-bst">See the problem</a>
    /// </summary>
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null)
        {
            return null;
        }

        if (key < root.val)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (key > root.val)
        {
            root.right = DeleteNode(root.right, key);
        }
        else
        {
            if (root.left == null)
            {
                return root.right;
            }
            else if (root.right == null)
            {
                return root.left;
            }

            root.val = MinValue(root.right);
            root.right = DeleteNode(root.right, root.val);
        }

        return root;
    }

    private int MinValue(TreeNode node)
    {
        var min = node.val;

        while (node.left != null)
        {
            min = node.left.val;
            node = node.left;
        }

        return min;
    }
}

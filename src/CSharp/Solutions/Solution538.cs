using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution538
{
    /// <summary>
    /// 538. Convert BST to Greater Tree - Medium
    /// <a href="https://leetcode.com/problems/convert-bst-to-greater-tree">See the problem</a>
    /// </summary>
    public TreeNode ConvertBST(TreeNode root)
    {
        var sum = 0;
        Traverse(root, ref sum);
        return root;
    }

    private void Traverse(TreeNode node, ref int sum)
    {
        if (node == null)
        {
            return;
        }

        Traverse(node.right, ref sum);
        sum += node.val;
        node.val = sum;
        Traverse(node.left, ref sum);
    }
}
